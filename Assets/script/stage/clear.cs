using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clear : MonoBehaviour {
	//プレイヤーが触れた時クリア
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			time_script.clearcheck = true;//クリアチェック動作
			Fade_Out.next = "title";//シーンの移動先を指定
			Fade_Out.fade_ok = true;//フェードアウト
		}
	}
}
