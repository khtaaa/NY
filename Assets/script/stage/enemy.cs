using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {
	Vector3 spos;//最初の座標
	float range=5;//移動距離（片道）
	int direction=1;//移動方向
	Rigidbody2D RG;//リジットボディ
	public float speed = 5.0f;//移動速度

	void Start () {
		spos = transform.position;//初期座標獲得
		RG = GetComponent<Rigidbody2D> ();//リジットボディ獲得
	}

	void Update () {
		//プラス座標に一定距離行ったらマイナス座標に方向を切り替える
		if (transform.position.x > spos.x + range) {
			direction=-1;
		}

		//マイナス座標に一定距離行ったらプラス座標に方向を切り替える
		if (transform.position.x < spos.x - range) {
			direction = 1;
		}

	}

	void FixedUpdate(){
		RG.velocity = new Vector2 (speed*direction, RG.velocity.y);//移動
	}

}
