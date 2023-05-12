using System.Collections.Generic; 
using Unity.Collections;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using ZXing;

public class QrCodeRecenter : MonoBehaviour
{
    [SerializeField]
    private ARSession session;
    [SerializeField]
    private ARSessionOrigin sessionOrigin;
    [SerializeField]
    private ARCameraManager cameraManager;
    [SerializeField]
    private List<Target> navigationTargetObjects = new List<Target>();

    private Texture2D cameraImageTexture;
    private IBarcodeReader reader = new BarcodeReader(); // create an object for barcode reader 
    Messages msg;

    private bool scanOn=false; //indicates if it is scanning

    private void Update()
    {
        msg = GameObject.FindGameObjectWithTag("Message").GetComponent<Messages>();
        if (Input.GetKeyDown(KeyCode.Space)) //for pc testing
        {
            SetQrCodeRecenterTarget("Project Room");
        }
    }
    private void OnEnable()
    {
        cameraManager.frameReceived += OnCameraFrameReceived;
    }

    private void OnDisable()
    {
        cameraManager.frameReceived -= OnCameraFrameReceived;
    }
    //activate for each frame
    private void OnCameraFrameReceived(ARCameraFrameEventArgs eventArgs)
    {

        if(!scanOn)
            return;
        if (!cameraManager.TryAcquireLatestCpuImage(out XRCpuImage image))
        {
            return;
        }

        var conversionParams = new XRCpuImage.ConversionParams
        {
            // Get the entire image.
            inputRect = new RectInt(0, 0, image.width, image.height),

            outputDimensions = new Vector2Int(image.width / 2, image.height / 2),

            // Choose RGBA format.
            outputFormat = TextureFormat.RGBA32,

            // Flip across the vertical axis (mirror image).
            transformation = XRCpuImage.Transformation.MirrorY
        };

        // Total Bytes For final image
        int size = image.GetConvertedDataSize(conversionParams);

        // Creater to store the image.
        var buffer = new NativeArray<byte>(size, Allocator.Temp);

        // Convert the image data from buffer
        image.Convert(conversionParams, buffer);
        
        image.Dispose();

        cameraImageTexture = new Texture2D(
            conversionParams.outputDimensions.x,
            conversionParams.outputDimensions.y,
            conversionParams.outputFormat,
            false);

        cameraImageTexture.LoadRawTextureData(buffer);
        cameraImageTexture.Apply();

        buffer.Dispose();

        // Checks to decode the barcode 
        var result = reader.Decode(cameraImageTexture.GetPixels32(), cameraImageTexture.width, cameraImageTexture.height);

        if (result != null)
        {
            SetQrCodeRecenterTarget(result.Text);
            scanOn = false;
            msg.scaningText.SetActive(false);
            StartCoroutine(msg.DisplayTextForSecond(msg.scanDoneText, 1));
        }
        Destroy(cameraImageTexture);
    }
    public void TurnOnScan(){
        scanOn = !scanOn;
        msg.scaningText.SetActive(scanOn);
        msg.instrText.SetActive(false);
    }
    //with qrcode being decoded, the session origin is moved to the new location
    public void SetQrCodeRecenterTarget(string targetText)
    {
        Target currentTarget = navigationTargetObjects.Find(x => x.Name.ToLower().Equals(targetText.ToLower()));
        if (currentTarget != null)
        {
            // Reset position and rotation of ARSession
            session.Reset();

            // Add offset for recentering
            sessionOrigin.transform.position = currentTarget.PositionObject.transform.position;
            sessionOrigin.transform.rotation = currentTarget.PositionObject.transform.rotation;
        }
    }

}