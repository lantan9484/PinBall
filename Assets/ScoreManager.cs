using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

	private int score;
	private GameObject scoreText;

	// Use this for initialization
	void Start () {
		score = 0;
		//シーン中のScoreTextオブジェクトを取得
		this.scoreText = GameObject.Find("ScoreText");
	}

	void OnCollisionEnter(Collision other){
		string ScoreTag = other.gameObject.tag;
		if (ScoreTag == "SmallStarTag") {
			//Debug.Log("衝突！");
			score += 10;
		} else if (ScoreTag == "LargeStarTag") {
			score += 50;
		} else if (ScoreTag == "SmallCloudTag") {
			score += 30;
		} else if (ScoreTag == "LargeCloudTag") {
			score += 100;
		} 
		this.scoreText.GetComponent<Text> ().text = "score:" + score;
	}
		
	// Update is called once per frame
	void Update () {
		//Debug.Log ("点数" + score);

	}
	// void addscoreをつくってもよいかも
}
