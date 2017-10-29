using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class time_script : MonoBehaviour {
	public static float cleartime;
	public static bool clearcheck;
	public float nowtime;

	// Use this for initialization
	void Start () {
		clearcheck = false;
		nowtime = 0;
	}
	
	// Update is called once per frame
	void Update () {
		nowtime += Time.deltaTime;
		if (clearcheck) {
			//cleartime = Mathf.Round(nowtime*100)/100;
			cleartime=nowtime;
			clearcheck = false;
		}
	}
}
