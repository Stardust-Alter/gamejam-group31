using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourthEvent : HappenEvent
{
    GameObject axis;
    bool bookInArea = false;
    public GameObject rain;
    // Start is called before the first frame update
    private void Start()
    {
        axis = GameObject.Find("WindowAxis");

    }
    public override void StartEvent()
    {
        base.StartEvent();
        axis.GetComponent<WindowScripts>().isOpen = true;
        rain.SetActive(true);

        SEManagement._Instance.PlaySE("Talk10");
        SEManagement._Instance.PlaySE("WinOpen");
        SEManagement._Instance.PlaySE("RainSound");

    }
    // Update is called once per frame
    void Update()
    {
        if(isOn==true)
        {
            if (EventManagement._Instance.candleIsIn == true && EventManagement._Instance.bookIsIn == true)
            {
                SEManagement._Instance.PlaySE("Talk13", 0.5f);
                 StartCoroutine(EqPlayer());
                EndEvent();
            }
            else
            {
                //TODO 蚊子飞
            }

            if (axis.GetComponent<WindowScripts>().isOpen == false)
            {
                rain.SetActive(false);
             
            }
        }
    }

    private IEnumerator EqPlayer()
    {
        yield return new WaitForSeconds(2f);

        SEManagement._Instance.PlaySE("EqSound");

        yield return new WaitForSeconds(1.4f);

        SEManagement._Instance.PlaySE("Talk14");


         StartCoroutine(EqPlayer2());

    }

    private IEnumerator EqPlayer2()
    {
        yield return new WaitForSeconds(3.5f);
        //Debug.Log("Down");
        SEManagement._Instance.PlaySE("GlassDown");
        SEManagement._Instance.PlaySE("CansDown");
        SEManagement._Instance.PlaySE("WoodDown");
    }
}
