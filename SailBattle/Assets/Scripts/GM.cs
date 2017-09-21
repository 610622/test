using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour {
    public float updateRate = 2f;
    //updateRate初始为2秒，这里可以更改更改风向频率
    float lastTime = 0;
    //lastTime初始为0
    public  float windRotation;
    //用作static方便访问
    public GameObject sail;
    //获取船帆的GameObject
    public  float Angle;
    //风向和船帆的角度差，定义为static方便使用
    public static GM Instance;
    // Use this for initialization
    void Start ()
    {
        Instance = this;
    }
	// Update is called once per frame
	void Update () {
        /*
        float sailAngle = sail.transform.eulerAngles.z;
        //eulerAngles返回的值是个角度值，并且是全局的角度
        Angle = windRotation - sailAngle;
        //求风向和船帆的角度差
        */

        //float time = Time.time;
        ////time持续增长
        //if (time-lastTime>updateRate)
        ////当time比lastTime大2秒的时候执行ChangeWind函数
        //{
        //    //Debug.Log("wind changed");
        //    ChangeWind();
        //    lastTime = time;
        //    //lastTime会变更为最近一次风向改变时的执行时间
        //}
    }
    public void ChangeWind()
    {
        windRotation = Random.Range(0,360);
        //从0到360之间给出一个随机的值
    }
}
