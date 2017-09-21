using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MatchRoomCanvasFunc : MonoBehaviour {

    public Text userNameText;

	// Use this for initialization
	void Start () {
        userNameText.text = "Welcome:" + UserInfo.userName;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LogoutButton()
    {
        SceneManager.LoadScene("LoginScene");
    }
}
