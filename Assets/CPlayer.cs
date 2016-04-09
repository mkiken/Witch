using UnityEngine;
using System.Collections;

public class CPlayer : MonoBehaviour {

//	http://am1tanaka.hatenablog.com/entry/2015/05/15/211002
//	public float VEL = 40f;

	// ボールのプレハブ
	public GameObject prefBall = null;

	// ボールのインスタンス
	GameObject insBall = null;
	GameObject insBall2 = null;


	// Use this for initialization
	void Start () {
		createHoldBall ();
	
	}
	
	// Update is called once per frame
	void Update () {
		//	http://am1tanaka.hatenablog.com/entry/20111109/132084678
		// ボールの発射
		if (insBall != null){
			// 砲台の周りを回転させる処理
			insBall.SendMessage ("rotateBall", transform);

			if (Input.GetButton("Jump")){
				insBall.SendMessage ("shotBall", transform);
				insBall = null;
			}
		}
		if (insBall == null && insBall2 == null){
			createHoldBall ();
		}
	
	}

	// ボールを生成して、砲台にくっつける
	void createHoldBall(){
		// ローカル変数としてVector3型の「bpos」を宣言して、プレイヤーバーの現在位置(transform.position)を代入
		Vector3 bpos = transform.position;

		// bposのY座標(bpos.y)に、プレイヤーバーの高さ(collider.bounds.size.y)と
		// ボールの高さ(prefBall.transform.localScale.y)の合計を2で割ったものを加えると、
		// 求めたい座標が計算できる
		bpos.y += (GetComponent<Collider> ().bounds.size.y + prefBall.transform.localScale.y) / 2f;

		/*
「prefBall」からボールの実体を生成(Instantiate)する
座標はbpos
回転はなし(Quaternion.identity)
				*/
		insBall = (GameObject)Instantiate (prefBall, bpos, Quaternion.identity);
		insBall2 = insBall;
		insBall.AddComponent <CBall> ();
		/*
生成したボールをプレイヤーバーの子オブジェクトにする
生成したボールのインスタンス(insBall)の姿勢情報(transform)の親(parent)に、プレイヤーバーの姿勢情報(transform)を設定することで、子オブジェクトとすることが出来る
		*/
		insBall.transform.parent = transform;
		insBall.SendMessage ("setBattery", this);
	}

	public void stopPlayerBall (){
		insBall2 = null;
	}
}
