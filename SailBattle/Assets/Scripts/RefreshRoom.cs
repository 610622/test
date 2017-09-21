using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;

public class RefreshRoom : MonoBehaviour {
    private NetworkManager networkMG;
    List<GameObject> roomList = new List<GameObject>();
    //因为不知有多少房间，所以用链表形式创建
    [SerializeField]
    GameObject JoinRoomButton;
    [SerializeField]
    Transform JoinRoomContent;
	void Start () {
        networkMG = NetworkManager.singleton;
        if (networkMG.matchMaker == null)
        //如果matchMaker为空，就开出一个matchMaker
        {   networkMG.StartMatchMaker();}
    }	
	void Update () {	
	}
    public void RefreshRoomButton()
    {   networkMG.matchMaker.ListMatches(0,20,"",true,0,0,OnMatchList);}
    public void OnMatchList(bool success, string extendedInfo, List<MatchInfoSnapshot> matches)
    {
        if(!success)
        {   Debug.Log("refresh game unsuccess");
            return;}
        ClearRoomList();
        //刷新功能之前清理上次刷新的结果
        foreach (MatchInfoSnapshot match in matches)
        //MatchInfoSnapshot这个类是用来保存比赛信息的一个类
        {
            Debug.Log("match name:"+match.name+"is added");
            GameObject _JoinRoomPrefb = Instantiate(JoinRoomButton,JoinRoomContent);
            //创建并指定创建位置
            JoinGame jg = _JoinRoomPrefb.GetComponent<JoinGame>();
            jg.SetupRoom(match);
            //这样可使创建的match都能传到JoinRoom中
            roomList.Add(_JoinRoomPrefb);
            //将预制体加到list中
        }
    }
    void ClearRoomList()
    {
        for(int i=0;i<roomList.Count;i++)
        {   Destroy(roomList[i]);}
        roomList.Clear();
    }
}