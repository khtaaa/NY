using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delblock : MonoBehaviour {
	public float deltime=5.0f;//線の消える時間
	player PL;//プレイヤー

	void Start () {
		PL = GameObject.Find ("player").GetComponent<player> ();//プレイヤーのスクリプトを獲得
		PL.linebar--;//線の量を1減らす
		Invoke ("del", deltime);//一定時間後にdel関数を動作させる
	}

	void del()
	{
		this.gameObject.SetActive (false);//線を非表示
		Invoke ("puls", deltime);//一定時間後にpuls関数を動作させる
	}

	void puls()
	{
		PL.linebar++;//線の量を1増やす
		Destroy (gameObject);//このオブジェクトを削除する
	}
}
