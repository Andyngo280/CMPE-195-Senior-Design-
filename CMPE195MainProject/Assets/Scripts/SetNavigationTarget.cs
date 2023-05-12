using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SetNavigationTarget : MonoBehaviour
{
    // [SerializeField]
    // private TMP_Dropdown navigationTargetDropDown;
    //[SerializeField]
    //private List<Target> navigationTargetObject = new List<Target>(); 

    public GameObject ButtonPrefab;
    public GameObject ButtonParent; 

    public GameObject TargetHolder;
    
    public GameObject RoomHolder;
    public GameObject StairHolder;
    public GameObject FountainHolder;
    public GameObject BathroomHolder;

    public List<Target> Targets = new List<Target>();
    public int totalTargets; 

    private NavMeshPath path; //calcualted path
    private LineRenderer line; //display path
    private Vector3 targetPosition = Vector3.zero; 

    private bool lineToggle = true;

    // Start is called before the first frame update

    private void Start()
    {
        path = new NavMeshPath();
        line = transform.GetComponent<LineRenderer>();
        line.enabled = lineToggle;
        totalTargets = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        if (lineToggle && targetPosition != Vector3.zero)
        {
            NavMesh.CalculatePath(transform.position, targetPosition, NavMesh.AllAreas, path);
            line.positionCount = path.corners.Length;
            line.SetPositions(path.corners);
        }
        if (totalTargets==0){//floor switched
            foreach(Transform tr in TargetHolder.transform){
                if(tr.tag == "RoomHolder") 
                    RoomHolder = tr.gameObject;
                if(tr.tag == "StairHolder") 
                    StairHolder = tr.gameObject;
                if(tr.tag == "FountainHolder") 
                    FountainHolder = tr.gameObject;
                if(tr.tag == "BathroomHolder") 
                    BathroomHolder = tr.gameObject;
            }
            totalTargets = RoomHolder.transform.childCount;
            for(int i=0; i<totalTargets; i++){
                Target temp = new Target();
                temp.init(RoomHolder.transform.GetChild(i).gameObject, RoomHolder.transform.GetChild(i).name);
                Targets.Add(temp);
            }
            for(int i=0; i<totalTargets; i++){
                GameObject newButton = Instantiate(ButtonPrefab, ButtonParent.transform);
                newButton.GetComponentInChildren<TextMeshProUGUI>().text = RoomHolder.transform.GetChild(i).name;
                newButton.GetComponent<Button>().onClick.AddListener(() => SetTargetFromSearch());
            }
            targetPosition = Vector3.zero; 
        }
    }

    private void OnEnable(){
    }
    //extract the name of button that sends the signal and set it as the destination
    public void SetTargetFromSearch(){
        string roomName = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<TextMeshProUGUI>().text;
        Target currentTarget = Targets.Find(x => x.Name.Equals(roomName));
        if(currentTarget != null){
            targetPosition = currentTarget.PositionObject.transform.position; 
        }
    }
    public void FindStair(){
        SetClosestObject(StairHolder);
    }
    public void FindFountain(){
        SetClosestObject(FountainHolder);
    }
    public void FindBathroom(){
        SetClosestObject(BathroomHolder);
    }
    //compares paths to all same kind of object and set the closest one as target
    public void SetClosestObject(GameObject holder){
        NavMeshPath tempPath = new NavMeshPath();
        float shortLen=float.MaxValue;
        Transform closestObject=null;
        foreach(Transform Object in holder.transform){
            if(!NavMesh.CalculatePath(transform.position, Object.gameObject.transform.position, NavMesh.AllAreas, tempPath))
                continue;
            float curLen = GetPathLength(tempPath);
            if(curLen<shortLen){
                shortLen = curLen;
                closestObject = Object;
            }
        }
        if(closestObject!=null)
            targetPosition = closestObject.gameObject.transform.position;
    }
    //calculate the length of a path
    public static float GetPathLength( NavMeshPath path )
    {
        float len = 0.0f;
        if (( path.status != NavMeshPathStatus.PathInvalid ))
        {
            for ( int i = 1; i < path.corners.Length; ++i )
            {
                len += Vector3.Distance( path.corners[i-1], path.corners[i] );
            }
        }
        else return float.MaxValue;
        return len;
    }
    //toggle the path line visibility
    public void ToggleVisibility()
    {
        lineToggle = !lineToggle;
        line.enabled = lineToggle;
    }
}
