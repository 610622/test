using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityEngine.UI;

public class CreatGame : MonoBehaviour {

    private NetworkManager networkMG;
    public string roomName;
    public uint roomSize = 4;
    //后面使用的方法中要求使用uint，uint比int要稍小
    private InputField inputField;

	// Use this for initialization
	void Start () {
        networkMG = NetworkManager.singleton;
        //把当前玩家正使用的NetworkManager赋给变量
        if(networkMG.matchMaker==null)
        //如果matchMaker为空，就开出一个matchMaker
        {
            networkMG.StartMatchMaker();
        }
        inputField = GetComponentInChildren<InputField>();
    }

    // Update is called once per frame
    void Update () {
		
	}

    //获取Input Field中的文字，让我新开出的房间名等于这些文字
    public void SetRoomName(string _name)
    {
        roomName = inputField.text;
        //函数内部命名时添加下划线方便编写
        Debug.Log(roomName);
    }

    //Button中的创建房间功能
    public void CreatRoom()
    {
        networkMG.matchMaker.CreateMatch(roomName,roomSize,true,"","","",0,0,networkMG.OnMatchCreate);
            //这里查找里CreateMatch的使用方法，说明见文档
    }

}
