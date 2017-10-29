using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clear : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			time_script.clearcheck = true;
			Fade_Out.next = "title";
			Fade_Out.fade_ok = true;
		}
	}
}
