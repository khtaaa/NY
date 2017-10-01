using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
	public float speed = 5.0f;
	public Sprite[] walk;
	int AnIn;
	bool walkCheck;
	// Use this for initialization
	void Start () {
		AnIn = 0;
		walkCheck = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (walkCheck) {
			AnIn++;
			if (AnIn >= walk.Length) {
				AnIn = 0;
			}
			GetComponent<SpriteRenderer> ().sprite = walk [AnIn];
		}

		if (Input.GetButton ("Fire1"))
		{
			walkCheck = true;
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed, GetComponent<Rigidbody2D> ().velocity.y);
		}
		else if(Input.GetButtonUp("Fire1")&&walkCheck)
		{
			walkCheck = false;
			GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		}
	}
}
