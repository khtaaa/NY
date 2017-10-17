using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2 : MonoBehaviour {
	float attacktime=0;
	public float maxtime=600;
	public GameObject attackobj;
	GameObject player;
	public float speed=5f;

	// Use this for initialization
	void Start () {
		attacktime = 0;
		player = GameObject.Find ("player");
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 v2;
		v2 = new Vector2 (player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);

		if(Vector2.Distance(player.transform.position,transform.position)<9){
		attacktime += Time.deltaTime;
		if (attacktime > maxtime) {
			attacktime = 0;
			GameObject obj = Instantiate (attackobj) as GameObject;
			obj.transform.position = transform.position;
			obj.GetComponent<Rigidbody2D> ().velocity = v2.normalized*speed;
		}
		}
	}
}
