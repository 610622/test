using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class BoatStats : NetworkBehaviour {

    public int maxHealth = 100;
    //血条写成整数型更好操作更符合实际
    [SyncVar][SerializeField]
    //服务器同步：不光在自己的服务器上更改显示，还需要让其他玩家都看到
    private int curHealth;
    [SyncVar]
    [SerializeField]
    private int kills;
    [SyncVar]
    [SerializeField]
    private int deaths = 0;
    [SerializeField]
    private GameObject[] objsNeedToDisable;

    public Text deathText;
	// Use this for initialization
	void Start () {
        deathText = GameObject.Find("Canvas/Death Number").GetComponent<Text>();
        curHealth = maxHealth;
        //初始化是开始血量等于最大血量
        deathText.text = deaths + "";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void TakeDamage(int damage)
    //受到伤害时血量减少一个damage值
    { 
        curHealth -= damage;
        Debug.Log("damage take called,curHealth is:" + curHealth);
        if(curHealth<0)
        {
            Respawn();
        }
    }
    void Respawn()
    {
        for (int i=0;i<objsNeedToDisable.Length;i++)
        {
            objsNeedToDisable[i].SetActive(false);
        }
        deaths += 1;
        deathText.text = deaths + "";
        StartCoroutine(SettingRespawn());
  
    }
    //协程方法控制死亡等待时间
    IEnumerator SettingRespawn()
    {
        yield return new WaitForSeconds(3f);
        //等待3秒就复活
        curHealth = maxHealth;
        Transform _spawnPoint = NetworkManager.singleton.GetStartPosition();
        transform.position = _spawnPoint.position;
        transform.rotation = _spawnPoint.rotation;
        for (int i = 0; i < objsNeedToDisable.Length; i++)
        {
            objsNeedToDisable[i].SetActive(true);
        }
    }

    public int GetCurHealth()
    {
        return curHealth;
    }//因为血量是私有值，这里需要写一个函数来获取血量，并设为公有
}
