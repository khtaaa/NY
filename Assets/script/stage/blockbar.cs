﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class blockbar : MonoBehaviour {
	Slider SL;
	stats ST;
	// Use this for initialization
	void Start () {
		ST = GameObject.Find ("player").GetComponent<stats> ();
		SL = this.gameObject.GetComponent<Slider> ();
		SL.maxValue = ST.MAXlinebar;
	}
	
	// Update is called once per frame
	void Update () {
		SL.value = ST.linebar;
	}
}
