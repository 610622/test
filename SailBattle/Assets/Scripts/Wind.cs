using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = Quaternion.Euler(0, 0, GM.Instance.windRotation);
        // transform.rotation不能直接赋值，要用 Quaternion来进行赋值，XY值不变只变更Z值
    }
}
