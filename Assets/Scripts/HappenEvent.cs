using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HappenEvent : MonoBehaviour
{
    public Action EventEnd;
    public bool isOn=false;

    public void StartEvent()
    {
        isOn = true;
        Debug.Log("事件开始");
    }

    public void EndEvent()
    {
        isOn = false;
        EventEnd();
    }
}
