using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
	public int HP=50;//体力
	public int MAXHP=50;//最大体力
	public float linebar=50;//線の量
	public float MAXlinebar=50;//線の最大の量
	public float speed=5.0f;//移動速度
	public bool invincible=false;//無敵確認
	public bool walkCheck = false;//移動確認
	public bool gameover = false;//ゲームオーバー確認
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
	//stats ST;//ステータス
	public GameObject gameover_text;//ゲームオーバーテキスト

	void Start () {
		//ST = GetComponent<stats> ();//ステータス獲得
		RG = GetComponent<Rigidbody2D> ();//Rigidbody2D獲得
		AnIn = 0;//アニメーション初期化
		walkCheck = false;//移動判定初期化
		invincible = false;//無敵初期化
		playerM = this.gameObject.GetComponent<Renderer> ();//プレイヤーのレンダラー獲得
	}

	void Update () {
		//移動判定
		if (walkCheck) {
			AnIn++;//アニメーションカウント

			//アニメーション判定
			if (AnIn >= walk.Length) {
				AnIn = 0;//アニメーションカウント初期化
			}
			GetComponent<SpriteRenderer> ().sprite = walk [AnIn];//アニメーション
		}

		//ダメージを受けたら点滅、無敵
		if (invincible)
		{
			//点滅
			FlashingTimer += Time.deltaTime;//点滅タイマー

			//点滅タイマー判定
			if (FlashingTimer > maxFlashing) {
				playerM.enabled = !playerM.enabled;//表示と非表示入れ替え
				FlashingTimer = 0;//点滅タイマー初期化
			}

			//無敵
			invincibleTimer+=Time.deltaTime;//無敵タイマー

			//無敵タイマー判定
			if (invincibleTimer > maxinvincible) {
				invincibleTimer = 0;//無敵タイマー初期化
				invincible = false;//無敵解除
				playerM.enabled = true;//プレイヤー表示
			}
		}

		//ゲームオーバー判定
		if (gameover == false) {
			gameover_text.transform.localPosition =new Vector3 (gameover_text.transform.localPosition.x, 10, gameover_text.transform.localPosition.z);

			if ((Input.GetKey (KeyCode.A)) || (Input.GetKey (KeyCode.D))) {

				direction = Mathf.Sin (Input.GetAxis ("Horizontal"));//現在向いている方向と

				//最後に向いている方向を保存
				if (direction != 0) {
					last_direction = direction;//現在向いている方向を最後に向いている方向に代入
				}

				walkCheck = true;//移動中

			} else if ((Input.GetKeyUp (KeyCode.A) || Input.GetKeyUp (KeyCode.D))) {
				walkCheck = false;//移動していない
				direction = 0;//どっちもむいていない
			}

		} else {
			if (gameover_text.transform.localPosition.y > 4) {
				gameover_text.transform.localPosition += Vector3.down*0.05f;
			}

			//ゲームオーバーのときに左クリックで
			if (Input.GetMouseButtonDown (0)) {
				Fade_Out.next = "title";
				Fade_Out.fade_ok = true;
			}
		}
	}

	void FixedUpdate(){
		if (gameover == false) {
			RG.velocity = new Vector2 (speed * direction, RG.velocity.y);
		}

	}

	//ダメージ判定
	void damagecheck()
	{
		//ダメージを受けてHPが無くなったらゲームオーバー
		if ((HP - MAXHP / 10) <= 0) {
			gameover = true;
		} else {
			//無敵中じゃなければダメージを食らって無敵にする
			if (invincible == false) {
				HP -= MAXHP / 10;//ダメージ
				invincible = true;//無敵
			}
		}
	}

	void OnCollisionStay2D(Collision2D col) 
	{
		//エリア外に落下したらゲームオーバー
		if (col.collider.CompareTag ("gameover")) {
			gameover = true;
		}

			//トラップに触れた時
		if (col.collider.CompareTag ("trap")) {
			damagecheck ();//ダメージ確認
		}

			//敵に触れたとき
		if (col.collider.CompareTag ("enemy")) {
			//RG.velocity = new Vector2 (10 * col.gameObject.GetComponent<enemy> ().direction, RG.velocity.y);
			damagecheck ();//ダメージ確認
		}

	}

	void OnCollisionEnter2D(Collision2D col)
	{
		//プレイヤーが動く床に乗った時プレイヤーを動く床の子オブジェクトにする
		if (col.gameObject.CompareTag ("movefloor")) {
			transform.SetParent(col.transform);
		}
	}

	void OnCollisionExit2D(Collision2D col) 
	{
		//プレイヤーが動く床から降りた時プレイヤーを動く床の子オブジェクトからはずす
		if (col.gameObject.CompareTag ("movefloor")) {
			transform.SetParent(null);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		//敵の攻撃に触れた時
		if (other.gameObject.CompareTag ("enemy")) {
			damagecheck ();//ダメージ確認
		}
	}

}
