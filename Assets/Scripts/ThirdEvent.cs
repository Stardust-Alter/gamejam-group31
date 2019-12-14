using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdEvent : HappenEvent
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isOn==true)
        {
            if(EventManagement._Instance.firstOut==true&& EventManagement._Instance.SecondOut==true)
            {
                EndEvent();
            }
            else
            {
                //TODO 蚊子飞
            }
        }
    }
}
