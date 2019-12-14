﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondWindEvent : HappenEvent
{
    public float damage = 0.5f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isOn)
        {
            if (EventManagement._Instance.leftHandIn && EventManagement._Instance.rightHandIn)
            {
                GameManagement._Instance.RecoverHealth(0.6f * Time.deltaTime);
            }
            else
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
