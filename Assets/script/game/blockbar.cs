using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class blockbar : MonoBehaviour {
	Slider SL;
	public static float RA;
	public static float MAXRA = 50;
	// Use this for initialization
	void Start () {
		SL = this.gameObject.GetComponent<Slider> ();
		SL.maxValue = MAXRA;
		RA = MAXRA;
	}
	
	// Update is called once per frame
	void Update () {
		SL.value = RA;
	}
}
