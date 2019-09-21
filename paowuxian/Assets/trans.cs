using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trans : MonoBehaviour
{
    public float xspeed = 5;//水平方向初速度
    public float zspeed = 0;
    public float g = 10;//重力加速度
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 myVector = new Vector3(Time.deltaTime * xspeed, -Time.deltaTime * zspeed, 0);
        this.transform.Translate(myVector);
        zspeed += g * Time.deltaTime;
    }
}


