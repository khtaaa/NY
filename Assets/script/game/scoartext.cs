﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoartext : MonoBehaviour {

	void Start () {
		GetComponent<TextMesh> ().text = "scora:"+time_script.cleartime.ToString("000.00");
	}

}