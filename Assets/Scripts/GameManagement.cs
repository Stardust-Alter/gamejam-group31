using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagement : MonoBehaviour
{
    public static GameManagement _Instance;

    private int health = 100;

    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
            if(health<=0)
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GetHurt(int hurt)
    {
        health = -hurt;
    }

    void GameOver()
    {
        //TODO       
    }
}
