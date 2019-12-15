using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MothInCandle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Moth")
        {
            EventManagement._Instance.mothCount++;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Moth")
        {
            EventManagement._Instance.mothCount--;
        }
    }
}
