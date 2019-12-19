using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStart : HappenEvent
{
    public GameObject candle;
    public GameObject startTips;
    public Text tip;
    GameObject darkPercent;
    GameObject fire;
    float color = 0f;
    bool isLight = false;
    float timer = 0;
    
    public override void StartEvent()
    {
        base.StartEvent();
        candle.SetActive(true);
        startTips.SetActive(true);
        darkPercent = GameObject.FindGameObjectWithTag("MainCamera");
        fire = GameObject.FindGameObjectWithTag("Fire");
        darkPercent.GetComponent<ScreenEffects>().darkPercent = 1;
        StartCoroutine(PlayTalk1());
        GameObject.Find("Lamp").SetActive(false);

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isOn)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isLight = true;
                SEManagement._Instance.PlaySE("MatchFire");
                startTips.SetActive(false);
            }

            if (color < 255)
            {
                color += 0.2f * Time.deltaTime;
            }
            tip.color = new Color(color, color, color);
            if (isLight)
            {
                darkPercent.GetComponent<ScreenEffects>().darkPercent -= 0.5f * Time.deltaTime;
                if (fire.GetComponent<Light>().intensity < 1.6f)
                {
                    fire.GetComponent<Light>().intensity += 0.05f;
                }
                timer += Time.deltaTime;
            }
            if (timer >= 3f)
            {
                GameObject.Find("GameManagement").GetComponent<GameManagement>().enabled = true;
                EndEvent();
            }
        }
    }

    IEnumerator PlayTalk1()
    {
        SEManagement._Instance.PlaySE("LampDown");

        yield return new WaitForSeconds(0.7f);

        SEManagement._Instance.PlaySE("Talk1",0.5f); 
        
    }
}
