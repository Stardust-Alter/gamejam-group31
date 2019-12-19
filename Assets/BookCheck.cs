using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookCheck : MonoBehaviour
{
    bool playFlag = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Book"&& playFlag==false)
        {
            EventManagement._Instance.bookIsIn = true;
            EventManagement._Instance.candleIsIn = true;
            
            playFlag = true;
        }
    }
}
