using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moth : MonoBehaviour
{
    GameObject[] waypoints = null;                      //路径点
    Transform[] wayTrans = null;                        //各路径点坐标系组件
    int index = 0;                                      //路径点索引
    public float moveSpeed = 1f;                        //移动速度
    public float rotateSpeed = 0.5f;                    //旋转速度
    public float awayRotSpeed = 5f;                     //急转旋转速度
    public float switchDistance = 0.1f;                 //更改目标路径的最小距离
    float timer = 0;                                    //移动计时器
    Vector3 direction;                                  //方向向量
    Vector3 awayPoint = new Vector3(1000, 1000, 1000);  //远离点
    Vector3 resetPoint = new Vector3(1000, 1000, 1000); //重置点
    public bool isAway = false;                         //是否远离
    public bool isRound = false;                        //是否环绕
    public bool isLeave = false;                        //是否离开
    int count = 0;                                      //阻挡计数

   static bool isPlayTalk = false;
    //float circleRate = 0.1f;        //盘旋飞行的概率

    // Start is called before the first frame update
    void Start()
    {
        waypoints = GameObject.FindGameObjectsWithTag("WayPoint");
        wayTrans = new Transform[waypoints.Length + 2];
        for (int i = 0; i < waypoints.Length; i++)
        {
            wayTrans[i] = waypoints[i].GetComponent<Transform>();
        }
        wayTrans[waypoints.Length] = GameObject.FindGameObjectWithTag("Fire").transform;
        wayTrans[waypoints.Length + 1] = GameObject.Find("MothLeavePoint").transform;
        direction = wayTrans[index].position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (!Away())
        {
            RotAndMove();
            direction = wayTrans[index].position - transform.position;
        }
        if (isLeave == true)
        {
            Leave();
        }
        else if (isRound)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 90);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.FromToRotation(Vector3.up, direction), (isAway ? awayRotSpeed : rotateSpeed) * timer);
            transform.position += transform.rotation * (Vector3.up) * moveSpeed * Time.deltaTime;
        }

        if(Input.GetKeyDown(KeyCode.G))
        {
            //Debug.Log("CheatLeave");
            Leave();
            //direction = wayTrans[wayTrans.Length - 1].position- transform.position;
        }
    }

    void RotAndMove()
    {
        if ((transform.position - wayTrans[index].position).magnitude <= switchDistance && index < waypoints.Length)
        {
                timer = 0;
                ++index;
        }
        else if ((transform.position - wayTrans[waypoints.Length].position).magnitude <= 0.12f)
        {
            isRound = true;
        }
    }

    bool Away()
    {
        RaycastHit raycastHit;
        if (Physics.Raycast(transform.position, direction, out raycastHit, 0.5f) && raycastHit.collider.tag == "Hand" && !isAway)
        {
            timer = 0;
            awayPoint = transform.position + (direction - Vector3.Project(direction, raycastHit.normal)) * 2;
            isAway = true;
            count++;
            //Debug.Log("count=" + count);
            if (count >= 3)
            {
                if(isPlayTalk==false)
                { 
                    SEManagement._Instance.PlaySE("TtoF2");
                    isPlayTalk = true;
                }
                isLeave = true;
            }
        }
        if (awayPoint != resetPoint && (transform.position - awayPoint).magnitude > switchDistance)
        {
            direction = awayPoint - transform.position;
            return true;
        }
        else
        {
            awayPoint = resetPoint;
            isAway = false;
            return false;
        }
    }

    void Leave()
    {
        direction = wayTrans[wayTrans.Length - 1].position - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.FromToRotation(Vector3.up, direction), (isAway ? awayRotSpeed : rotateSpeed) * timer);
        transform.position += transform.rotation * (Vector3.up) * moveSpeed * Time.deltaTime;
    }

    void Circle()
    {
        if (true)
        {

        }
    }

}
