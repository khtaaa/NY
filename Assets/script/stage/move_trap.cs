using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_trap : MonoBehaviour {
	private Vector3 pos;//座標
	public float speed=5.0f;//移動速度
	public float distance=10;//距離

	// Use this for initialization
	void Start () {
		pos = transform.position;//初期座標を代入
	}
	
	// Update is called once per frame
	void Update () {
		//移動
		this.gameObject.transform.position = new Vector2 (pos.x , pos.y+ Mathf.PingPong (Time.time*speed, distance));
	}
}
