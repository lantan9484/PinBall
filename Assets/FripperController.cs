using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FripperController : MonoBehaviour {
	//HingeJointコンポーネントを入れる
	private HingeJoint myHingeJoint;

	//初期の傾き
	private float defaultAngle = 20;
	//弾いた時の傾き
	private float flickAngle = -20;

	// Use this for initialization
	void Start () {
		//HingeJointコンポーネント取得
		this.myHingeJoint = GetComponent<HingeJoint>();

		//フリッパーの傾きを設定
		SetAngle(this.defaultAngle);
	}

	// Update is called once per frame
	void Update () {
		foreach (Touch t in Input.touches) {

			if (t.phase == TouchPhase.Began || t.phase == TouchPhase.Moved || t.phase == TouchPhase.Stationary) {
				//画面の左半分をタッチした時左フリッパーを動かす
				if (t.position.x < Screen.width * 0.5 && tag == "LeftFripperTag") {
					SetAngle (this.flickAngle);
				}
				//画面の右半分をタッチした時右フリッパーを動かす
				if (t.position.x >= Screen.width * 0.5 && tag == "RightFripperTag") {
					SetAngle (this.flickAngle);
				}
			}
			//指が離された時フリッパーを元に戻す
			if (t.phase == TouchPhase.Ended) {
				if (t.position.x < Screen.width * 0.5 && tag == "LeftFripperTag") {
					SetAngle (this.defaultAngle);
				}
				if (t.position.x >= Screen.width * 0.5 && tag == "RightFripperTag") {
					SetAngle (this.defaultAngle);
				}
			}
			
		}
	}


	//フリッパーの傾きを設定
	public void SetAngle (float angle){
		JointSpring jointSpr = this.myHingeJoint.spring;
		jointSpr.targetPosition = angle;
		this.myHingeJoint.spring = jointSpr;
	}
}