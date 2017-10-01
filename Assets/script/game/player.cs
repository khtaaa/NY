using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
	public float speed = 5.0f;
	public Sprite[] walk;
	float AD;
	float lastAD; 
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

		if (Input.GetKey(KeyCode.A )|| Input.GetKey(KeyCode.D))
		{
			AD=Input.GetAxis("Horizontal");
			if (AD != 0)
				lastAD = AD;
			walkCheck = true;
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed*AD, GetComponent<Rigidbody2D> ().velocity.y);
		}
		else if((Input.GetKeyUp(KeyCode.A)||Input.GetKeyUp(KeyCode.D))&&walkCheck)
		{
			walkCheck = false;
			GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		}
	}
}
