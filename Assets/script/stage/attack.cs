using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour {
	public int AD;
	public float speed=1.0f;
	// Use this for initialization
	void Start () {
		Destroy (gameObject,1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed*AD, GetComponent<Rigidbody2D> ().velocity.y);
	}

	void OnTriggerEnter2D(Collider2D other) {
			Destroy (gameObject,0.3f);
	}
}
