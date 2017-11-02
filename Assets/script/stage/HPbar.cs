using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbar : MonoBehaviour {
	Slider SL;//シリンダー
	player PL;//プレイヤー

	void Start () {
		PL = GameObject.Find ("player").GetComponent<player> ();//プレイヤーのスクリプト獲得
		SL = this.gameObject.GetComponent<Slider> ();//シリンダー獲得
		SL.maxValue = PL.MAXHP;//シリンダーの最大値をMAXHPにする
	}

	void Update () {
		SL.value = PL.HP;//シリンダーの現在の値をプレイヤーのHPにする
	}
}
