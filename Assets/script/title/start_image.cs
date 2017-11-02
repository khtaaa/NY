using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start_image : MonoBehaviour {
	float start_time;//スタートボタン拡大縮小用タイマー
	Vector3 minscale=new Vector3(0.8f,0.8f,0.8f);//最低サイズ
	Vector3 maxscale =new Vector3(1.2f,1.2f,1.2f);//最高サイズ

	void Start () {
		start_time = 0;//タイマーリセット
	}

	void Update () {
		start_time += Time.deltaTime;//タイマー
		transform.localScale = Vector3.Lerp (minscale, maxscale, 0.5f * Mathf.Sin (start_time) + 0.5f);//スタートボタン拡大縮小
	}
}
