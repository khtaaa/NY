using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbar : MonoBehaviour {
	Slider SL;
	stats ST;

	void Start () {
		ST = GameObject.Find ("player").GetComponent<stats> ();
		SL = this.gameObject.GetComponent<Slider> ();
		SL.maxValue = ST.MAXHP;
	}
	
	// Update is called once per frame
	void Update () {
		SL.value = ST.HP;
	}
}
