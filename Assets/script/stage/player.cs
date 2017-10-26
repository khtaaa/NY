using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
	public Sprite[] walk;//移動画像
	Rigidbody2D RG;//Rigidbody2D
	float direction;//現在入力してる方向
	float last_direction; //最後に向いていた方向
	int AnIn;//アニメーション用変数
	float FlashingTimer=0;//点滅用タイマー
	float maxFlashing=0.5f;//点滅間隔
	float invincibleTimer=0;//無敵用タイマー
	float maxinvincible=3;//無敵時間
	Renderer playerM;//Renderer
	stats ST;//ステータス


	void Start () {
		ST = GetComponent<stats> ();//ステータス獲得
		RG = GetComponent<Rigidbody2D> ();
		AnIn = 0;
		ST.walkCheck = false;
		ST.damage = false;
		playerM = this.gameObject.GetComponent<Renderer> ();
	}

	void Update () {
		if (ST.walkCheck) {
			AnIn++;
			if (AnIn >= walk.Length) {
				AnIn = 0;
			}
			GetComponent<SpriteRenderer> ().sprite = walk [AnIn];
		}

		//ダメージを受けたら点滅、無敵
		if (ST.damage)
		{
			//点滅
			FlashingTimer += Time.deltaTime;
				if(FlashingTimer>maxFlashing)
				{
				playerM.enabled = !playerM.enabled;
				FlashingTimer = 0;
				}

			//無敵
			invincibleTimer+=Time.deltaTime;
			if (invincibleTimer > maxinvincible) 
			{
				invincibleTimer = 0;
				ST.damage = false;

				playerM.enabled = true;
			}
		}

		if ((Input.GetKey(KeyCode.A ))||( Input.GetKey(KeyCode.D)))
		{

			direction = Mathf.Sin (Input.GetAxis ("Horizontal"));//現在向いている方向と

			//最後に向いている方向を保存
			if (direction != 0) {
				last_direction = direction;//現在向いている方向を最後に向いている方向に代入
			}

			ST.walkCheck = true;

		}
		else if((Input.GetKeyUp(KeyCode.A)||Input.GetKeyUp(KeyCode.D)))
		{
			ST.walkCheck = false;
			direction = 0;
			//RG.velocity = Vector2.zero;
		}
	}

	void FixedUpdate(){
		RG.velocity = new Vector2 (ST.speed*direction, RG.velocity.y);

	}

	void OnCollisionStay2D(Collision2D col) 
	{
		
		if (ST.damage == false) {
			//トラップに触れた時
			if (col.collider.CompareTag ("trap")) {
				ST.damage = true;
				ST.HP -= ST.MAXHP / 10;
			}

			//敵に触れたとき
			if (col.collider.CompareTag ("enemy")) {
				RG.velocity = new Vector2 (10 * col.gameObject.GetComponent<enemy> ().direction, RG.velocity.y);
				ST.damage = true;
				ST.HP -= ST.MAXHP / 10;

			}
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.CompareTag ("movefloor")) {
			transform.SetParent(col.transform);
		}
	}

	void OnCollisionExit2D(Collision2D col) 
	{
		if (col.gameObject.CompareTag ("movefloor")) {
			transform.SetParent(null);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("enemy")) {
			if (ST.damage == false) {
				ST.damage = true;
				ST.HP -= ST.MAXHP / 10;
			}
		}
	}

}
