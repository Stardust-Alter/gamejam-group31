using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstWindEvent : HappenEvent
{
    public float damage = 0.25f;
    GameObject axis;
    public override void StartEvent()
    {
        base.StartEvent();
        axis.GetComponent<WindowScripts>().isOpen = true;
    }
    void Start()
    {
        axis = GameObject.Find("WindowAxis");
    }

    // Update is called once per frame
    void Update()
    {
        if (isOn)
        {
            if (EventManagement._Instance.leftHandIn || EventManagement._Instance.rightHandIn)
            {
                GameManagement._Instance.RecoverHealth(0.5f * Time.deltaTime);
            }
            else if (axis.GetComponent<WindowScripts>().isOpen)
            {
                GameManagement._Instance.GetHurt(damage * Time.deltaTime);
            }
            if (GameManagement._Instance.Health == 4)
            {
                EndEvent();
            }
        }
    }

}
