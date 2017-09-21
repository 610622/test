using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSprites : MonoBehaviour {
    public GameObject[] sprites;
    int curHealth;
    BoatStats bs;
	void Start () {
        bs = GetComponentInParent<BoatStats>();
        for (int i = 0; i < sprites.Length; i++)
        {
            sprites[i].SetActive(false);
        }
        sprites[0].SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
        curHealth = bs.GetCurHealth();
        if (curHealth > 70)
        {
            SetActiveSprites(0);
        }
        if (curHealth > 30 && curHealth <= 70)
        {
            SetActiveSprites(1);
        }
        if (curHealth <= 30)
        {
            SetActiveSprites(2);
        }
    }

    void SetActiveSprites(int _index)
    {
        for (int i = 0; i < sprites.Length; i++)
        {
            sprites[i].SetActive(false);
        }
        //避免其它的状态是开启的
        sprites[_index].SetActive(true);
    }
}
