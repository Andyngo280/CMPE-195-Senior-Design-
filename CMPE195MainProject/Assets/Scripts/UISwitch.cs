using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISwitch : MonoBehaviour
{
    public GameObject Interactives;

    private bool active = false;
    //toggle the visibility of some UI
    public void ToggleUI(){
        Interactives.SetActive(active);
        active=!active;
    }
}
