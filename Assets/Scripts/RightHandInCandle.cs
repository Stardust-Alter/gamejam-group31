using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHandInCandle : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "R_hand")
        {
            Debug.Log("右手进入");
            EventManagement._Instance.rightHandIn = true;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.name == "R_hand")
        {
            Debug.Log("右手退出");
            EventManagement._Instance.rightHandIn = false;
        }
    }
}
