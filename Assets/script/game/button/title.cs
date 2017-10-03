using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class title : MonoBehaviour {
	public void OnClickButton()
	{
		Fade_Out.fade_ok = true;
		Fade_Out.next="title";
	}
}
