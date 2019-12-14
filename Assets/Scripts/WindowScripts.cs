using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowScripts : MonoBehaviour
{
    public float currentAngle = 0f;
    public float angleRotateMix = 0f;
    public float angleRotateMax = 90f;
    public float rotateSpeed = 360f;
    public GameObject rotateAxie = null;
    // Start is called before the first frame update
    void Start()
    {
        currentAngle = transform.rotation.y;
        rotateAxie = GameObject.FindGameObjectWithTag("WindowAxis");
    }

    // Update is called once per frame
    void Update()
    {
        currentAngle = transform.rotation.eulerAngles.y;
        if (currentAngle < angleRotateMax)
            transform.RotateAround(rotateAxie.transform.position, rotateAxie.transform.up, rotateSpeed * Time.deltaTime);
        else
            transform.rotation = Quaternion.Euler(0, 90, 0);
    }
}
