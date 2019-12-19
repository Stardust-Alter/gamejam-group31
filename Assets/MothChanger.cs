using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MothChanger : MonoBehaviour
{
    bool isCheak=false;
    GameObject[] gameObjects;
    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        gameObjects = GameObject.FindGameObjectsWithTag("Moth");
    }

    // Update is called once per frame
    void Update()
    {
        if(count>2)
        {
            EventManagement._Instance.ThirdOut = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Moth"&&isCheak==false)
        {
            other.GetComponent<Moth>().enabled = false;
            count++;
            
            StartOtherMoth();
          
            isCheak = true;
        }
        else if(other.tag == "Moth" && isCheak )
        {
            other.GetComponent<Moth>().enabled = false;
            count++;
        }
        //Debug.Log(count);
    }

    
    public void StartOtherMoth()
    {
        gameObjects[1].GetComponent<Moth>().enabled = true;
        SEManagement._Instance.PlaySE("Talk6");
        StartCoroutine(StartLastMoth());

    }

    IEnumerator StartLastMoth()
    {
        yield return new WaitForSeconds(3);
        SEManagement._Instance.PlaySE("Talk7");
        gameObjects[2].GetComponent<Moth>().enabled = true;
    }

}
