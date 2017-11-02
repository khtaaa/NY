using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movefloor : MonoBehaviour {
	private Vector3 pos;//座標
	public float speed=5.0f;//移動速度
	public float distance=10;//距離
	public bool start;//プレイヤーの乗車確認
	public float time=0;//移動用タイマー

	void Start () {
		start = false;
		pos = transform.position;//初期座標を代入
	}

	void Update () {
		if (start) {
			//移動
			time+=Time.deltaTime;
			this.gameObject.transform.position = new Vector2 (pos.x + Mathf.PingPong (time * speed, distance), pos.y);
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		//プレイヤーが乗ったら動作
		if (col.gameObject.CompareTag ("Player")) {
			start = true;
		}
	}
}
