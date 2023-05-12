using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Messages : MonoBehaviour
{
    public GameObject instrText;    //scan code instruction
    public GameObject warnText;     //warning message
    public GameObject scaningText;  //scanning
    public GameObject scanDoneText; //scan complete
 
    // Start is called before the first frame update
    void Start()
    {
        //disable everything except the scan code instruction
        instrText.SetActive(true);
        scaningText.SetActive(false);
        scanDoneText.SetActive(false);
        warnText.SetActive(false);
    }
    //function that displays certain text object for certain amount of time
    public IEnumerator DisplayTextForSecond(GameObject txtObj, int time){
        txtObj.SetActive(true);
        yield return new WaitForSeconds(time);
        txtObj.SetActive(false);
    }

    // Update is called once per frame
    
}
