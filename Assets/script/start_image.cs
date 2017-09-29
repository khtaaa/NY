using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start_image : MonoBehaviour {
	float start_time;
	Vector3 minscale=new Vector3(1.5f,1.5f,1.5f);
	Vector3 maxscale =new Vector3(2.5f,2.5f,2.5f);
	// Use this for initialization
	void Start () {
		start_time = 0;
	}
	
	// Update is called once per frame
	void Update () {
		start_time += Time.deltaTime;
		transform.localScale = Vector3.Lerp (minscale, maxscale, 0.5f * Mathf.Sin (start_time) + 0.5f);
	}
}
