using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoar : MonoBehaviour {
	public bool scoracheck;
	public GameObject kannbann;
	public float speed=0.5f;

	void Start () {
		scoracheck = false;
	}
	

	void Update () {
		if (scoracheck) {
			if (kannbann.transform.position.x < -6) {
				kannbann.transform.position += Vector3.right*speed;
			}
		} else {
			if (kannbann.transform.position.x > -11) {
				kannbann.transform.position += Vector3.left*speed;
			}
		}
	}

	public void OnClickButton()
	{
		scoracheck = !scoracheck;
	}
}
