using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delblock : MonoBehaviour {
	public float deltime=5.0f;
	// Use this for initialization
	void Start () {
		blockbar.RA--;
		Invoke ("del", deltime);
	}

	void del()
	{
		blockbar.RA++;
		Destroy (gameObject);
	}
}
