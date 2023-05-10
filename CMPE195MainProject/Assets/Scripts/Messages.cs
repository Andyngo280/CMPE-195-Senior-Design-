using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Messages : MonoBehaviour
{
    public GameObject instrText;
    public GameObject warnText;
    public GameObject scaningText;
    public GameObject scanDoneText;
 
    // Start is called before the first frame update
    void Start()
    {
        instrText.SetActive(true);
        scaningText.SetActive(false);
        scanDoneText.SetActive(false);
        warnText.SetActive(false);
    }
    public IEnumerator DisplayTextForSecond(GameObject txtObj, int time){
        txtObj.SetActive(true);
        yield return new WaitForSeconds(time);
        txtObj.SetActive(false);
    }

    // Update is called once per frame
    
}
