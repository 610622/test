using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Boat : NetworkBehaviour {

    public float xSpeed = 0.5f;
    //船转弯的速度
    public float ySpeed = 1f;
    //船前进的速度
    public float yMaxSpeed = 3f;
    //船前进的最大速度

    public GameObject sail;

    public float Angle;

    public GameObject bullet;
    public Transform[] cannonHeads;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        SpeedCheck();

        float sailAngle = sail.transform.eulerAngles.z;
        //eulerAngles返回的值是个角度值，并且是全局的角度
        Angle = GM.Instance.windRotation - sailAngle;
        //求风向和船帆的角度差

        transform.Translate(Vector2.up*ySpeed*Time.deltaTime);
        //*Time.deltaTime的目的是为了防止时间受帧数的影响，更真实
        if (Input.GetKey("a"))
        {
            transform.Rotate(Vector3.forward * xSpeed);
        }
        if (Input.GetKey("d"))
        {
            transform.Rotate(Vector3.forward * -xSpeed);
        }
        //键盘a，d键控制船转弯
        if (Input.GetKey("w") && (sail.transform.localEulerAngles.z<90|| sail.transform.localEulerAngles.z > 269))
        {
            sail.transform.Rotate(Vector3.forward * xSpeed);
            //Debug.Log(sail.transform.localEulerAngles.z);
        }
        if (Input.GetKey("s") && (sail.transform.localEulerAngles.z<91|| sail.transform.localEulerAngles.z >270))
        {
            sail.transform.Rotate(Vector3.forward * -xSpeed);
            //Debug.Log(sail.transform.localEulerAngles.z);
        }
        //键盘w，s键控制船帆旋转，船帆转向时有限度值，不能转过与船竖直的180度，但因实现时具体数值不为人为认定的值
        //进行了调试和修改
    }

    void SpeedCheck()//顺风速度大。逆风速度小
    {
        if ((Angle >= 0 && Angle < 180) || (Angle < -180 && Angle > -360))
        {
            if(Angle>0)
            {
                float def = System.Math.Abs(Angle - 90); 
                float rate = 1 - def / 90;
                //Debug.Log(rate);
                ySpeed = yMaxSpeed* rate;
            }
            if (Angle < 0)
            {
                float def = System.Math.Abs(Angle + 270);
                float rate = 1 - def / 90;
                //Debug.Log(rate);
                ySpeed = yMaxSpeed * rate;
            }
        }
        if (Angle > 180 || (Angle > -180 && Angle < 0))
        {
            ySpeed = 0.1f;
        }
    }

    [Command]
    public void Cmd_Shoot(int direction)
    {
        //direction1为右边，direction0为左边
        Quaternion bulletAngle = Quaternion.Euler(0,0,Random.Range(-15f,15f)+cannonHeads[direction].transform.eulerAngles.z);
        GameObject _bullet = Instantiate(bullet, cannonHeads[direction].position, bulletAngle);
        //生成子弹，位置受角度影响
        NetworkServer.Spawn(_bullet);
    }
}
