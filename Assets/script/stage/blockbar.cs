using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class blockbar : MonoBehaviour {
	Slider SL;//シリンダー
	player PL;//プレイヤー

	void Start () {
		PL = GameObject.Find ("player").GetComponent<player> ();//プレイヤーのスクリプト獲得
		SL = this.gameObject.GetComponent<Slider> ();//シリンダー獲得
		SL.maxValue = PL.MAXlinebar;//シリンダーの最大値をMAXlinebarにする
	}

	void Update () {
		SL.value = PL.linebar;//シリンダーの現在の値をプレイヤーのlinebarにする
	}
}
