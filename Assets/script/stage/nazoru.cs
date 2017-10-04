using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nazoru : MonoBehaviour {
	public GameObject[] line;
	public GameObject[] damy;
	public int lineN;
	public float lineL=0.2f;
	public float lineW = 0.1f;
	Vector3 Tpos;
	// Use this for initialization
	void Start () {
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

		if (blockbar.RA > 0) {
			if (Input.GetMouseButtonDown (0)) {
				Tpos = Input.mousePosition;	
				Tpos = Camera.main.ScreenToWorldPoint (Tpos);
				Tpos.z = 0;
			}


			if (Input.GetMouseButton (0)) {
			
				Vector3 Spos = Tpos;
				Vector3 Epos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				Epos.z = 0;

				if ((Epos - Spos).magnitude > lineL) {
					//RaycastHit2D hit = Physics2D.BoxCast (Tpos,new Vector2(), Vector3.forward,Mathf.Infinity,LayerMask.GetMask("enemy","player","floor"));
					RaycastHit2D[] hit = new RaycastHit2D[5]; // Physics2D.Raycast (Tpos, Vector3.forward,Mathf.Infinity,LayerMask.GetMask("enemy","player","floor"));
					GameObject obj = Instantiate (line [lineN], (Spos + Epos) / 2 + Vector3.back * 5f, transform.rotation) as GameObject;
					obj.transform.right = (Epos - Spos).normalized;
					obj.transform.localScale = new Vector3 ((Epos - Spos).magnitude, lineW, lineW);
					obj.transform.parent = this.transform;
					if (obj.GetComponent<BoxCollider2D> ().Cast (Vector2.zero, hit, 0f) != 0) {
						Destroy (obj);
						obj = Instantiate (damy [lineN], (Spos + Epos) / 2 + Vector3.back * 5f, transform.rotation) as GameObject;
						obj.transform.right = (Epos - Spos).normalized;
						obj.transform.localScale = new Vector3 ((Epos - Spos).magnitude, lineW, lineW);
						obj.transform.parent = this.transform;
					}

					Tpos = Epos;
				}
			}
		}
	}
}
