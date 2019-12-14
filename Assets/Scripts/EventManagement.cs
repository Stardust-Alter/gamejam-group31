using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManagement : MonoBehaviour
{

    public static EventManagement _Instance; 

    public List<HappenEvent> eventlist= new List<HappenEvent>();

    private HappenEvent currentEvent;

    public bool leftHandIn = false;
    public bool rightHandIn = false;

    void Awake()
    {
        _Instance = this;
    }

    void Start()
    {
        eventlist.Add(GameObject.Find("Event1").GetComponent<HappenEvent>());
        eventlist.Add(GameObject.Find("Event2").GetComponent<HappenEvent>());
        StartCoroutine(Corutine_Wait(5));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartFirstEvent()
    {
        currentEvent = eventlist[0];
        currentEvent.EventEnd += StartNextEvent;
        currentEvent.StartEvent();
    }

    void StartNextEvent()
    {
        if (eventlist.Count == 0)
        {
            GameManagement._Instance.GameWin();
        }
        else
        {
            eventlist.Remove(eventlist[0]);
            StartFirstEvent();
        }

    }

    IEnumerator Corutine_Wait(float second)
    {
        yield return new WaitForSeconds(second);
        StartFirstEvent();
    }
}
