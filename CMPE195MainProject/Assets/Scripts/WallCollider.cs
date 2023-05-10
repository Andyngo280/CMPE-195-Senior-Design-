using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Wall")
        {
            print("Enter");
        }
    }

    void onTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            print("Stay");
        }
    }

    void onTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            print("Exit");
        }
    }
}
