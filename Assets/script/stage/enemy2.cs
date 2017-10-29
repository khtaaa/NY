using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2 : MonoBehaviour {
	float attacktime=0;//攻撃の時間
	public float maxtime=5;//攻撃発動の時間
	public GameObject attackobj;//攻撃オブジェ
	GameObject player;//プレイヤー
	public float speed=5f;//攻撃の移動速度
	public float distance=9;//距離

	void Start () {
		attacktime = maxtime/2;
		player = GameObject.Find ("player");//プレイヤーを代入
	}
	
	// Update is called once per frame
	void Update () {
		//プレイヤーの方向を計算
		Vector2 v2;
		v2 = new Vector2 (player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);

		//プレイヤーが一定距離に入ったら攻撃
		if(Vector2.Distance(player.transform.position,transform.position)<distance){
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
