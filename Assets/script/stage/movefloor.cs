using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movefloor : MonoBehaviour {
	private Vector3 pos;//座標
	public float speed=5.0f;//移動速度
	public float distance=10;//距離

	void Start () {
		pos = transform.position;//初期座標を代入
	}

	void FixedUpdate () {
		//移動
		this.gameObject.transform.position = new Vector2 (pos.x + Mathf.PingPong (Time.time*speed, distance), pos.y);
	}
}
