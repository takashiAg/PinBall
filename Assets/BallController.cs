using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

	//ボールが見える可能性のあるz軸の最大値
	private float visiblePosZ = -6.5f;

	//ゲームオーバを表示するテキスト
	private GameObject gameoverText;

	//スコアのカウント関数
	int score = 0;
	//スコアの表示用オブジェクト
	private GameObject ScoreText;

	// Use this for initialization
	void Start () {
		//シーン中のGameOverTextオブジェクトを取得
		this.gameoverText = GameObject.Find("GameOverText");
		this.ScoreText = GameObject.Find("ScoreText");
	}

	// Update is called once per frame
	void Update () {
		//ボールが画面外に出た場合
		if (this.transform.position.z < this.visiblePosZ) {
			//GameoverTextにゲームオーバを表示
			this.gameoverText.GetComponent<Text> ().text = "Game Over";
		}
	}
	void OnCollisionEnter(Collision other) {
		if (other.gameObject.CompareTag ("SmallStarTag")) {
			//score add 10
			this.ScoreAdd(10);
		} else if (other.gameObject.CompareTag ("LargeStarTag")) {
			//score add 20
			this.ScoreAdd(20);
		} else if (other.gameObject.CompareTag ("SmallCloudTag")) {
			//score add 15
			this.ScoreAdd(15);
		} else if (other.gameObject.CompareTag ("LargeCloudTag")) {
			//score add 25
			this.ScoreAdd(25);
		} else {
			Debug.Log("collision");
		}
	}
	void ScoreAdd (int S){
		Debug.Log (score);
		this.score = this.score + S;
		this.ScoreText.GetComponent<Text> ().text = "Score: "+this.score;
	}
}