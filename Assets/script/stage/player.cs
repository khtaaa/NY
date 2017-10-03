using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
	public float speed = 5.0f;
	public Sprite[] walk;
	public GameObject[] attack;
	public static int attack_LV=0;
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
	}

	void FixedUpdate(){
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

		if (Input.GetKeyDown (KeyCode.Space)) {
			GameObject obj = Instantiate (attack [attack_LV]) as GameObject;
			obj.transform.position = new Vector3 (transform.position.x + Mathf.Sign (lastAD)*1.5f, transform.position.y, transform.position.z);
			obj.GetComponent<attack> ().AD = (int)Mathf.Sign (lastAD);
		}
	}
}
