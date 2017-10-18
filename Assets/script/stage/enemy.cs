using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {
	Vector3 spos;
	float range=5;
	public int direction;
	Rigidbody2D RG;
	stats ST;
	// Use this for initialization
	void Start () {
		spos = transform.position;
		direction = 1;
		RG = GetComponent<Rigidbody2D> ();
		ST = GetComponent<stats> ();
	}
	
	// Update is called once per frame
	void Update () {
		RG.velocity = new Vector2 (ST.speed*direction, RG.velocity.y);

		if (transform.position.x > spos.x + range) {
			direction=-1;
		}

		if (transform.position.x < spos.x - range) {
			direction = 1;
		}

	}

	void OnCollisionStay2D(Collision2D col) {
		if (col.collider.CompareTag ("Player")) {
			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		}
	}

	void OnCollisionExit2D(Collision2D col) {
		if (col.collider.CompareTag ("Player")) {
			RG.velocity = Vector2.zero;
		}
	}

}
