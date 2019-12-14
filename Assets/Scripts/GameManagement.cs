using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagement : MonoBehaviour
{
    public static GameManagement _Instance;

    public Light candle_light;

    [SerializeField]
    private float brightness=0.1f;
    [SerializeField]
    private float health = 4;
    [SerializeField]
    private float floatbrightness;

    public float Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
            ChangeBrightness();
            if (health<=0)
            {
                GameOver();
            }
        }
    }


    void Awake()
    {
        _Instance = this;
    }

    void Start()
    {
        brightness = candle_light.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        LightFlame();
    }

    public void GetHurt(float hurt)
    {
        Health = -hurt;
    }

    private void ChangeBrightness()
    {
        if (Health<=4&&Health>3)
        {
            brightness = 1.6f;
        }
        if (Health <=3 && Health > 2)
        {
            brightness = 1.4f;
        }
        if (Health <=2 && Health > 1)
        {
            brightness = 0.8f;
        }
        if (Health <= 1 && Health > 0)
        {
            brightness = 0.4f;
        }
        if (Health== 0)
        {
            brightness = 0;
        }
    }



    void GameOver()
    {
        //TODO       
    }

    void LightFlame()
    {
        candle_light.intensity = Random.Range(brightness+ floatbrightness, brightness- floatbrightness);
    }

}
