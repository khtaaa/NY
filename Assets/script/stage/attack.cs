using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour {
	public float speed=1.0f;

	void Start () {
		Destroy (gameObject,speed);
	}

	void OnTriggerEnter2D(Collider2D other) {
			Destroy (gameObject);
	}
}
