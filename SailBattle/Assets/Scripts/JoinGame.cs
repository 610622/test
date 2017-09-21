using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityEngine.UI;

public class JoinGame : MonoBehaviour {
    public Text roomNametext;
    //用来修改列表中房间名
    private NetworkManager networkMG;
    public MatchInfoSnapshot match;
    // Use this for initialization
    void Start () {
        networkMG = NetworkManager.singleton;
        if (networkMG.matchMaker == null)
        //如果matchMaker为空，就开出一个matchMaker
        { networkMG.StartMatchMaker(); }
    }
    public void SetupRoom(MatchInfoSnapshot _match)
    {
        match = _match;
        roomNametext.text = _match.name;
    }
    public void JoinRoom()
    {
        networkMG.matchMaker.JoinMatch(match.networkId,"","","",0,0,networkMG.OnMatchJoined);
    }
}
