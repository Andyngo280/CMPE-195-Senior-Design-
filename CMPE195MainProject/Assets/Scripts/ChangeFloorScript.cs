using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFloorScript : MonoBehaviour
{
    SetNavigationTarget ind;
    QrCodeRecenter qr;
    Messages msg;
    public GameObject f1Target;
    public GameObject f2Target;
    public GameObject f3Target;
    public GameObject f4Target;
    public TMPro.TMP_Dropdown dropObject;
    // Start is called before the first frame update
    private void Start()
    {
        ind = GameObject.FindGameObjectWithTag("Indicator").GetComponent<SetNavigationTarget>();
        qr = GameObject.FindGameObjectWithTag("QR").GetComponent<QrCodeRecenter>();
        msg = GameObject.FindGameObjectWithTag("Message").GetComponent<Messages>();
        ChangeFloor();
    }
    //function that changes the current floor upon request
    public void ChangeFloor(){
        ClearList(); 
        switch(dropObject.value){
            case 0: 
                ind.TargetHolder = f1Target;
                qr.SetQrCodeRecenterTarget("F1 Stair1");
                break;
            case 1: 
                ind.TargetHolder = f2Target;
                qr.SetQrCodeRecenterTarget("F2 Stair1");
                break;
            case 2: 
                ind.TargetHolder = f3Target;
                qr.SetQrCodeRecenterTarget("Project Room");
                break;
            case 3: 
                ind.TargetHolder = f4Target;
                qr.SetQrCodeRecenterTarget("F4 Stair2");
                break;
            default: break;
        }
        StartCoroutine(msg.DisplayTextForSecond(msg.warnText, 2));
    }
    //clear the search list buttons
    private void ClearList(){
        for(int i=0; i<ind.totalTargets; i++){
            Destroy(ind.ButtonParent.transform.GetChild(i).gameObject);
        }
        ind.totalTargets = 0;
    }
}
