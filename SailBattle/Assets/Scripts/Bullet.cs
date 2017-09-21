using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Bullet : NetworkBehaviour {

    public float speed = 1;

    AudioSource _audio;

    //float tempTime = 0f;
	// Use this for initialization
	void Start () {
        //float time = Time.time;
        //tempTime = time;
        _audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        //transform.Translate(Vector2.up * speed * Time.deltaTime);
        //float time = Time.time;
        //if(time-tempTime>5)
        //{
            //Destroy(gameObject);
            //tempTime = time;
        //}
	}

    private void FixedUpdate()
    {
        if (!base.isServer)
            return;
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        Destroy(gameObject,5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _audio.Play();
            //Debug.Log("Bullet.2D is be diaoyong");
            BoatStats bs = collision.gameObject.GetComponentInParent<BoatStats>();
            //确保减少血量为进入范围的船只的血量
            bs.TakeDamage(10);
            //待等武器的类创建之后再详细写出
            Destroy(gameObject,0.3f);
        }
    }
}
