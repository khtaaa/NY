using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nazoru : MonoBehaviour {
	public GameObject[] line;
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
		if (Input.GetMouseButtonDown (1)) 
		{
			lineN++;
			if (lineN >= line.Length)
				lineN = 0;
		}

		if(blockbar.RA>0)
		{
		//lineのスタート地点
		if (Input.GetMouseButtonDown (0))
		{
			Tpos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Tpos.z = 0;
		}

		//lineをひく
		if (Input.GetMouseButton (0))
		{
			Vector3 Spos = Tpos;
			Vector3 Epos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Epos.z = 0;

			if ((Epos - Spos).magnitude > lineL) {
				GameObject obj = Instantiate (line [lineN], transform.position, transform.rotation) as GameObject;
				obj.transform.position = (Spos + Epos) / 2;
				obj.transform.right = (Epos - Spos).normalized;
				obj.transform.localScale = new Vector3 ((Epos - Spos).magnitude, lineW, lineW);
				obj.transform.parent = this.transform;
				Tpos = Epos;
			}
		}
		}
	}
}
