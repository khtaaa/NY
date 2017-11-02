using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_script : MonoBehaviour {
	bool scorecheck;//スコアボードが表示されていかどうか
	public GameObject score_board;//スコアボードオブジェクト
	public float speed=0.1f;//スコアボードの移動速度
	public float scorepos=-6;//スコアボード表示座標

	void Start () {
		scorecheck = false;//スコアボード非表示
	}


	void Update () {
		if (scorecheck) {
			//スコアボード表示座標より左なら設定になるまで移動
			if (score_board.transform.position.x < scorepos) {
				score_board.transform.position += Vector3.right*speed;//右に移動
			}
		} else {
			//スコアボード表示座標-5より右なら設定になるまで移動
			if (score_board.transform.position.x > -11) {
				score_board.transform.position += Vector3.left*speed;//左に移動
			}
		}
	}

	//スコアボード表示のボタン処理
	public void score()
	{
		scorecheck = !scorecheck;//スコア表示切替
	}

	//titleシーン移動のボタン処理
	public void title()
	{
		Fade_Out.fade_ok = true;//フェードアウト開始
		Fade_Out.next="title";//移動先のシーンの名前を設定
	}

	//バトルシーン移動のボタン処理
	public void battle()
	{
		Fade_Out.fade_ok = true;//フェードアウト開始
		Fade_Out.next="stage1";//移動先のシーンの名前を設定
	}
}
