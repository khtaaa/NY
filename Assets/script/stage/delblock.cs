using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delblock : MonoBehaviour {
	public float deltime=5.0f;
	stats ST;
	void Start () {
		ST = GameObject.Find ("player").GetComponent<stats> ();
		ST.linebar--;
		Invoke ("del", deltime);
	}

	void del()
	{
		this.gameObject.SetActive (false);
		Invoke ("puls", deltime);
	}

	void puls()
	{
		ST.linebar++;
		Destroy (gameObject);
	}
}
