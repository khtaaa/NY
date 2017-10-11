using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
	public Sprite[] walk;
	public GameObject[] attack;
	Rigidbody2D RG;
	public static int attack_LV=0;
	float AD;
	float lastAD; 
	int AnIn;
	float FlashingTimer=0;
	float maxFlashing=0.5f;
	float invincibleTimer=0;
	float maxinvincible=10;
	Renderer playerM;
	stats stats;


	void Start () {
		stats = GetComponent<stats> ();
		RG = GetComponent<Rigidbody2D> ();
		AnIn = 0;
		stats.walkCheck = false;
		stats.damage = false;
		playerM = this.gameObject.GetComponent<Renderer> ();
	}

	void Update () {
		if (stats.walkCheck) {
			AnIn++;
			if (AnIn >= walk.Length) {
				AnIn = 0;
			}
			GetComponent<SpriteRenderer> ().sprite = walk [AnIn];
		}

		//ダメージを受けたら点滅、無敵
		if (stats.damage)
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
				stats.damage = false;

				playerM.enabled = true;
			}
		}
	}

	void FixedUpdate(){
		if ((Input.GetKey(KeyCode.A ))||( Input.GetKey(KeyCode.D)))
		{
				AD = Input.GetAxis ("Horizontal");
			if (AD != 0)
				lastAD = AD;
			stats.walkCheck = true;
			RG.velocity = new Vector2 (stats.speed*AD, RG.velocity.y);
		}
		else if((Input.GetKeyUp(KeyCode.A)||Input.GetKeyUp(KeyCode.D)))
		{
			stats.walkCheck = false;
			RG.velocity = Vector2.zero;
		}


		if (Input.GetKeyDown (KeyCode.Space)) {
			GameObject obj = Instantiate (attack [attack_LV]) as GameObject;
			obj.transform.position = new Vector3 (transform.position.x + Mathf.Sign (lastAD)*1.5f, transform.position.y, transform.position.z);
			obj.GetComponent<attack> ().AD = (int)Mathf.Sign (lastAD);
		}
	}

	void OnCollisionStay2D(Collision2D col) {
		//トラップに触れた時
		if (stats.damage == false) {
			if (col.collider.CompareTag ("trap")) {
				stats.damage = true;
				stats.HP -= stats.MAXHP / 10;
			}

			if (col.collider.CompareTag ("enemy")) {
				RG.velocity = new Vector2 (10 * col.gameObject.GetComponent<enemy> ().direction, RG.velocity.y);
				stats.damage = true;
				stats.HP -= stats.MAXHP / 10;

			}
		}
	}

	void OnCollisionExit2D(Collision2D col) {
	}

}
