using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoretext : MonoBehaviour {
	void Start () {
		//現在のスコアを000：00のサイズで表示
		GetComponent<TextMesh> ().text = "Best record:"+time_script.cleartime.ToString("000.00");
	}
}
