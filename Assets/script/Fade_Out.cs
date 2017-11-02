using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fade_Out : MonoBehaviour {
	public float speed = 0.01f;//フェードアウト速度
	public float alfa;//アルファ値
	public static bool fade_ok;//フェードアウト確認
	public static string next;//次のシーンの名前

	void Start () {
		alfa = 0;//アルファ値初期化
		fade_ok = false;//フェードアウト非実行
		next = null;//次のシーン初期化
	}

	void Update () {
		//フェードアウト実行
		if (fade_ok) {
			alfa += speed;//一定速度でアルファ値増加
			GetComponent<Image> ().color = new Color (0, 0, 0, alfa);//アルファ値反映
			//アルファ値が1になったら停止させシーン切り替え
			if (alfa > 1) {
				fade_ok = false;//フェードアウト停止
				SceneManager.LoadScene (next);//シーン切り替え
			}
		}
	}
}
