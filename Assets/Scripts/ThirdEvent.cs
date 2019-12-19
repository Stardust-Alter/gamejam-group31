using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdEvent : HappenEvent
{
    public float damage = 0.3f;
    public float recover = 0.3f;
    GameObject moth;
    GameObject axis;
    // Start is called before the first frame update
    void Start()
    {
        axis = GameObject.Find("WindowAxis");
    }

    public override void StartEvent()
    {
        base.StartEvent();
 
        axis.GetComponent<WindowScripts>().isOpen = true;
        SEManagement._Instance.PlaySE("WinOpen");
        moth = GameObject.FindGameObjectWithTag("Moth");
        moth.GetComponent<Moth>().enabled = true;
        SEManagement._Instance.PlaySE("Talk5",0.5f);




    }

    // Update is called once per frame
    void Update()
    {
        if (isOn == true)
        {
            if (EventManagement._Instance.mothCount > 0)
            {
                GameManagement._Instance.GetHurt(damage * EventManagement._Instance.mothCount * Time.deltaTime);
            }
            else
            {
                GameManagement._Instance.RecoverHealth(recover * Time.deltaTime);
            }
            if (EventManagement._Instance.ThirdOut == true)
            {
                EndEvent();
            }
        }
    }


}
