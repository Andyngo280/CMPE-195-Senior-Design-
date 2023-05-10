using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISwitch : MonoBehaviour
{
    public GameObject Interactives;

    private bool active = false;
    public void ToggleUI(){
        Interactives.SetActive(active);
        active=!active;
    }
}
