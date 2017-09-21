using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BoatSetUp : NetworkBehaviour {

    [SerializeField]//为了显示到界面上面去
    Behaviour[] needToBeDisable;
    //Behaviour是包含了很多属性的大类，建立数组的形式更加方便更改
    //取得想要删掉的数组长度
    public short MsgId = 100;
    // Use this for initialization
    void Start () {

        if (!isLocalPlayer)//如果不是LocalPlayer
        {
            for (int i=0;i<needToBeDisable.Length;i++)
                //调用for循环
            {
                needToBeDisable[i].enabled = false;
                //递增数组长度，然后全部赋值为false
            }
        }
        if (isServer)
        {
            NetworkServer.RegisterHandler(MsgId, OnReciveMessage);
        }
        else
        {
            connectionToServer.RegisterHandler(MsgId, OnReciveMessage);
        }
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.A))
	    {
	        if (isServer)
	        {
                GM.Instance.ChangeWind();
                NetworkServer.SendToAll(MsgId, new SelectInfo(GM.Instance.windRotation));
	        }
	    }
	}
     public  void OnReciveMessage(NetworkMessage netMsg)
    {
        SelectInfo msg = netMsg.ReadMessage<SelectInfo>();

        if (isClient)
        {
            GM.Instance.windRotation = msg.angle;
        }
    }
}

public class SelectInfo : MessageBase
{
    public float angle;
    public SelectInfo()
    {
    
    }
    public SelectInfo(float angle)
    {
        this.angle = angle;
    }
}
