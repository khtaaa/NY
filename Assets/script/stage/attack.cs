using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour {
	public float speed=1.0f;//削除時間

	void Start () {
		Destroy (gameObject,speed);//生成後一定時間後に削除
	}

	void OnTriggerEnter2D(Collider2D other) {
			Destroy (gameObject);//何かに触れた時削除
	}
}
