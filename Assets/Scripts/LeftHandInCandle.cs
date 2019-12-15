using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHandInCandle : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.name== "L_hand")
        {
            Debug.Log("左手进入");
            EventManagement._Instance.leftHandIn = true;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.name == "L_hand")
        {
            Debug.Log("左手退出");
            EventManagement._Instance.leftHandIn = false;
        }
    }

}
