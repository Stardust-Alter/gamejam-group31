using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondWindEvent : HappenEvent
{
    public float damage = 0.5f;
    GameObject axis;
    bool losing = true;
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
            if (EventManagement._Instance.leftHandIn && EventManagement._Instance.rightHandIn)
            {
                GameManagement._Instance.RecoverHealth(0.6f * Time.deltaTime);
                if (GameManagement._Instance.Health == 4)
                {
                    losing = false;
                }
            }
            else if (losing && axis.GetComponent<WindowScripts>().isOpen)
            {
                GameManagement._Instance.GetHurt(damage * Time.deltaTime);
            }
            if (GameManagement._Instance.Health == 4 && axis.GetComponent<WindowScripts>().isOpen == false)
            {
                EndEvent();
            }
        }
    }
}
