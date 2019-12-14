using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    GameObject[] waypoints = null;
    int index = 0;
    float speed = 50f;
    float switchDistance = 0.1f;
    Vector3 lastPosition;
    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        waypoints = GameObject.FindGameObjectsWithTag("WayPoint");
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        Transform wayTrans = waypoints[index].GetComponent<Transform>();
        if ((transform.position - wayTrans.position).magnitude <= switchDistance)
        {
            if (index < waypoints.Length - 1)
            {
                timer = 0;
                lastPosition = transform.position;
                ++index;
            }
        }
        transform.position = Vector3.Slerp(lastPosition, wayTrans.position, timer);
    }
}
