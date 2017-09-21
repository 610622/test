using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatShoot : MonoBehaviour {

    Boat bs;
    AudioSource _audio;
    public int direction = 0;

    private void Awake()
    {
        bs = GetComponentInParent<Boat>();
        _audio = GetComponent<AudioSource>();
    }

    //public GameObject bullet;
    //public Transform cannonHead;
    float tempTime = 0f;
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey("q"))
        {
            bs.Cmd_Shoot(direction);

            //float time = Time.time;
            //if (time - tempTime > 1)
            //{
            //    Shoot();
            //    tempTime = time;
            //}
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag=="Player")
            //如果敌军船只进入攻击范围，就攻击
        {
            //BoatStats bs = col.gameObject.GetComponent<BoatStats>();
            //bs为进入范围的玩家的标记
            //bs.TakeDamage(10);
            float time = Time.time;
            if (time - tempTime > 1)
            {
                bs.Cmd_Shoot(direction);
                _audio.Play();
                tempTime = time;
            }
        }
    }

    //void Shoot()
    //{
    //    Quaternion bulletAngle = Quaternion.Euler(0,0,Random.Range(-15,15)+cannonHead.transform.eulerAngles.z);
    //    Instantiate(bullet, cannonHead.position, bulletAngle);
            //生成子弹，位置受角度影响
    //}
}
