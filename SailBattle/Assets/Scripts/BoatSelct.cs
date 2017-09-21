using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BoatSelct : MonoBehaviour {

    public GameObject[] sails;
    public GameObject[] flages;
    public GameObject[] smallsails;

    public GameObject shipButton0;
    public GameObject shipButton1;
    public GameObject shipButton2;
    public GameObject shipButton3;

    public Button ship0;
    public Button ship1;
    public Button ship2;
    public Button ship3;

    // Use this for initialization
    void Start () {

        shipButton0 = GameObject.Find("Ship0");
        shipButton1 = GameObject.Find("Ship1");
        shipButton2 = GameObject.Find("Ship2");
        shipButton3 = GameObject.Find("Ship3");

        ship0 = shipButton0.GetComponent<Button>();
        ship1 = shipButton1.GetComponent<Button>();
        ship2 = shipButton2.GetComponent<Button>();
        ship3 = shipButton3.GetComponent<Button>();

        ship0.onClick.AddListener(() => SetCharacter(0));
        ship1.onClick.AddListener(() => SetCharacter(1));
        ship2.onClick.AddListener(() => SetCharacter(2));
        ship3.onClick.AddListener(() => SetCharacter(3));

        for (int i = 0; i < sails.Length; i++)
        {
            sails[i].SetActive(false);
        }
        sails[0].SetActive(true);
        for (int i = 0; i < flages.Length; i++)
        {
            flages[i].SetActive(false);
        }
        flages[0].SetActive(true);
        for (int i = 0; i < smallsails.Length; i++)
        {
            smallsails[i].SetActive(false);
        }
        smallsails[0].SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetCharacter(int _index)
    {
        for (int i = 0; i < sails.Length; i++)
        {
            sails[i].SetActive(false);
        }
        sails[_index].SetActive(true);
        for (int i = 0; i < flages.Length; i++)
        {
            flages[i].SetActive(false);
        }
        flages[_index].SetActive(true);
        for (int i = 0; i < smallsails.Length; i++)
        {
            smallsails[i].SetActive(false);
        }
        smallsails[_index].SetActive(true);
    }
}
