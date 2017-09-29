using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {
	float posy;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		posy = (this.transform.position.y*-1)+5;
		if (posy < 0)
			posy = 0;
		this.transform.localScale =new Vector3 (posy,posy,posy);
	}
}
