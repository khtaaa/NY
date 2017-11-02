using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class title_start : MonoBehaviour {
	
	void Update () {
		//左クリックでゲームシーンに移動
		if (Input.GetMouseButtonDown (0)) {
			Fade_Out.fade_ok = true;//フェードアウト
			Fade_Out.next = "game";//次のシーンの名前
		}
		
	}
}
