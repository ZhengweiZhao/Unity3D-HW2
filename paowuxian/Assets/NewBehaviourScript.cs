using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
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
        this.transform.position += Vector3.right * Time.deltaTime * xspeed;
        this.transform.position += Vector3.down * Time.deltaTime * zspeed;
        zspeed += g * Time.deltaTime;
    }
}
