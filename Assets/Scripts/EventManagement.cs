using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManagement : MonoBehaviour
{

    public static EventManagement _Instance;

    public List<HappenEvent> eventlist = new List<HappenEvent>();

    private HappenEvent currentEvent;

    public bool leftHandIn = false;
    public bool rightHandIn = false;
    public bool firstOut = false;
    public bool SecondOut = false;
    public bool ThirdOut = false;
    public bool candleIsIn = false;
    public bool bookIsIn = false;
    public int mothCount = 0;


    void Awake()
    {
        _Instance = this;
    }

    void Start()
    {
        eventlist.Add(GameObject.Find("Start").GetComponent<HappenEvent>());
        eventlist.Add(GameObject.Find("Event1").GetComponent<HappenEvent>());
        eventlist.Add(GameObject.Find("Event2").GetComponent<HappenEvent>());
        eventlist.Add(GameObject.Find("Event3").GetComponent<HappenEvent>());
        //TODO 添加第四个关卡
        StartCoroutine(Corutine_Wait(3));
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
        eventlist.Remove(eventlist[0]);
        if (eventlist.Count == 0)
        {
            GameManagement._Instance.GameWin();
        }
        else
        {
            StartFirstEvent();
        }

    }

    IEnumerator Corutine_Wait(float second)
    {
        yield return new WaitForSeconds(second);
        StartFirstEvent();
    }
}
