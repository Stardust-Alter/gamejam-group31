using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowScripts : MonoBehaviour
{
    public bool isOpen = false;
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
        if (isOpen)
        {
            OpenWindow();
            
        }
        else
        {
            CloseWindow();
            
        }
    }

    void OpenWindow()
    {
        currentAngle = transform.rotation.eulerAngles.y;
        if (currentAngle < angleRotateMax)
            transform.RotateAround(rotateAxie.transform.position, rotateAxie.transform.up, rotateSpeed * Time.deltaTime);
        else
            transform.rotation = Quaternion.Euler(0, 90, 0);
    }
    void CloseWindow()
    {
        currentAngle = transform.rotation.eulerAngles.y;
        if (currentAngle > 0f && currentAngle < 90f)
            transform.RotateAround(rotateAxie.transform.position, rotateAxie.transform.up, -rotateSpeed * Time.deltaTime);
        else
            transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Hand" && Input.GetMouseButtonDown(0))
        {
            isOpen = false;
            SEManagement._Instance.PlaySE("WinClose");
        }
    }
}
