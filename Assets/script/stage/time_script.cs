using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class time_script : MonoBehaviour {
	public static float cleartime=999.99f;//クリア時間
	public static bool clearcheck;//クリアチェック
	public float nowtime;//現在の時間

	void Start () {
		clearcheck = false;//クリアチェック初期化
		nowtime = 0;//時間初期化
	}
	
	// Update is called once per frame
	void Update () {
		
		nowtime += Time.deltaTime;//時間測定

		//クリアがチェックされてとき起動
		if (clearcheck) {
			//記録が前回より早ければ記録更新
			if (cleartime > nowtime) {
				cleartime = nowtime;
				clearcheck = false;//クリアチェック初期化
			}
		}
	}
}
