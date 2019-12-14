using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class Hand : MonoBehaviour
{
    public Vector3 screenPosition;
    public Vector3 mousePositionOnScreen;
    public Vector3 mousePositionInWorld;

    public Transform leftHand;
    public Transform rightHand;
    Transform selectedHand;

    void Awake()
    {
        SwtichToLeftHand();
        Cursor.visible = false;//隐藏鼠标
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SwtichHand();
        MouseFollow();
    }

    [DllImport("user32.dll")]
    public static extern int SetCursorPos(int x, int y);

    public void SetMouseToScreenPosition()
    {
        screenPosition = Camera.main.WorldToScreenPoint(selectedHand.position);
        float setX = screenPosition.x;
        float setY = 1080 - screenPosition.y;

        SetCursorPos((int)setX, (int)setY);//强制设置坐标
        Debug.Log("更改鼠标位置");
    }

    void MouseFollow()
    {
        screenPosition = Camera.main.WorldToScreenPoint(selectedHand.position);
        mousePositionOnScreen = Input.mousePosition;
        mousePositionOnScreen.z = screenPosition.z;
        mousePositionInWorld = Camera.main.ScreenToWorldPoint(mousePositionOnScreen);
        selectedHand.position = new Vector3(mousePositionInWorld.x, mousePositionInWorld.y, selectedHand.position.z);
    }

    void SwtichHand()
    {
        if (Input.GetKeyDown("q") && selectedHand != leftHand)
        {
            SwtichToLeftHand();
        }
        if (Input.GetKeyDown("e") && selectedHand != rightHand)
        {
            SwtichToRightHand();
        }
    }

    void SwtichToLeftHand()
    {
        selectedHand = leftHand;
        SetMouseToScreenPosition();
    }

    void SwtichToRightHand()
    {
        selectedHand = rightHand;
        SetMouseToScreenPosition();
    }


}
