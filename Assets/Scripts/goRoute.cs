﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class goRoute : MonoBehaviour
{
    /*
    private Vector3[] position;
    private Vector3[] Position_formal;
    private int PointsNum = 0;
    public int mode = 0;    // 0 for recording, 1 for moving

    // Start is called before the first frame update
    void Start()
    {
        position = new Vector3[100];
        init_route();
    }

    // Update is called once per frame
    void Update()
    {
        if (mode == 0)
        {
            //record the moving route
            record_route(this.transform.position);
        }
        else  // mode == 1, moving mode
        {
            //move the gameobject as the route goes

        }

    }

    void record_route(Vector3 pos)
    {
        //record the current position
        if (Input.GetKey(KeyCode.Space))
        {
            position[++PointsNum] = pos;
            print(pos);
            // and write to a file(json)

        }
    }

    void init_route()
    {
        //read route from the file(json)

    }
    */
    //——————————————————————————————————————————————————————
    public GameObject[] gos; //获取每个目标点，，注意数组顺序不能乱
    public float speed = 1;  //用于控制移动速度
    int i = 0;             //用于记录是第几个目标点
    float des;             //用于存储与目标点的距离     
    
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //看向目标点
        this.transform.LookAt(gos[i].transform);
        //计算与目标点间的距离
        des = Vector3.Distance(this.transform.position, gos[i].transform.position);
        //移向目标
        transform.position = Vector3.MoveTowards(this.transform.position, gos[i].transform.position, Time.deltaTime * speed);
        //如果移动到当前目标点，就移动向下个目标
        if (des < 0.1f && i < 9)
        {
            i++;
        }

    }

}
