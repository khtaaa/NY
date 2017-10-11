using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nazoru : MonoBehaviour {
	public GameObject[] line;//lineオブジェクト
	public GameObject[] damy;//lineダミーオブジェクト
	public int lineN;//ラインの番号
	public float lineL=0.2f;//長さ
	public float lineW = 0.1f;//幅
	Vector3 Tpos;
	stats ST;

	void Start () {
		ST = GameObject.Find ("player").GetComponent<stats> ();
		lineN = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
		//lineの種類変更
		if (Input.GetMouseButtonDown (1)) {
			lineN++;
			if (lineN >= line.Length)
				lineN = 0;
		}

		//クリックした場所をTposに代入
			if (Input.GetMouseButtonDown (0)) {
			Tpos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				Tpos.z = 0;
			}
			
			if (Input.GetMouseButton (0)) {
			//スタート地点（spos）にtposを代入
			Vector3 Spos = Tpos;

			//現在の座標を最終地点（epos）に代入
			Vector3 Epos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Epos.z = 0;

			//スタート地点と最終地点の差がlineの長さより長かったらlineを生成
			if ((Epos - Spos).magnitude > lineL)  {
				//lineの容量が0以上ならline作成
				if (ST.linebar > 0) {
					RaycastHit2D[] hit = new RaycastHit2D[5];
					GameObject obj = Instantiate (line [lineN], (Spos + Epos) / 2 + Vector3.back * 5f, transform.rotation) as GameObject;
					obj.transform.right = (Epos - Spos).normalized;
					obj.transform.localScale = new Vector3 ((Epos - Spos).magnitude, lineW, lineW);
					obj.transform.parent = this.transform;
					//プレイヤー、エネミーとlineが重なっていたならlineをダミーに変更
					if (obj.GetComponent<BoxCollider2D> ().Cast (Vector2.zero, hit, 0f) != 0) {
						Destroy (obj);
						obj = Instantiate (damy [lineN], (Spos + Epos) / 2 + Vector3.back * 5f, transform.rotation) as GameObject;
						obj.transform.right = (Epos - Spos).normalized;
						obj.transform.localScale = new Vector3 ((Epos - Spos).magnitude, lineW, lineW);
						obj.transform.parent = this.transform;
					}
				}
				Tpos = Epos;
				}
			}
		}
	}

