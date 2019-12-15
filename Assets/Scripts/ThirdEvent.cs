using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdEvent : HappenEvent
{
    public float damage = 0.3f;
    public float recover = 0.3f;
    GameObject[] moth;
    // Start is called before the first frame update
    void Start()
    {

    }

    public override void StartEvent()
    {
        base.StartEvent();
        moth = GameObject.FindGameObjectsWithTag("Moth");
        moth[0].GetComponent<Moth>().enabled = true;
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
