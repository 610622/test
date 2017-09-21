using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectUI : MonoBehaviour {



	// Use this for initialization
	void Start () {
        Time.timeScale = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ConfirmButton()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
    }
}
