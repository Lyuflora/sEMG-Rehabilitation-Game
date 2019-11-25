using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionControl : MonoBehaviour
{
    // Use this for initialization
    //public GameObject gameObject;
    public float Speed = (float)(4);

    void Start()
    {
        //gameObject = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        /*//空格键抬升高度
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        }*/

        //w键前进
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(new Vector3(Speed * Time.deltaTime, 0, 0));
            //another version:
            //transform.Translate(Vector3.forward * Time.deltaTime * Speed);
        }
        //s键后退
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(new Vector3(-Speed * Time.deltaTime, 0, 0));
            //another version:
            //transform .Translate (Vector3 .forward *Time .deltaTime *-Speed) ;
        }
        //a键向左移动
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(new Vector3(0, 0, Speed * Time.deltaTime));
            /* this.transform.Translate(new Vector3(-1, 0, 0 * Time.deltaTime));*/
            //transform.Rotate(Vector3.up * Time.deltaTime * -2 * Speed);

        }
        //d键向右移动
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(new Vector3(0, 0, -Speed * Time.deltaTime));
            /* this.transform.Translate(new Vector3(1, 0, 0 * Time.deltaTime));*/
            //transform.Rotate(Vector3.up * Time.deltaTime * 2 * Speed);
        }
    }
}