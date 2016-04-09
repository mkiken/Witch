﻿using UnityEngine;
using System.Collections;

public class CBall : MonoBehaviour
{

	//	http://am1tanaka.hatenablog.com/entry/20111109/1320846783
	public float INIT_DEGREE = 75f;
	public float INIT_SPEED = 0.000001f;

	// 回転の中心になるオブジェクト
	//	public Transform centerOfRotate;
	// 回転のスピード
	public const float rotateSpeed = 20.0f;

	// 射出の際のスピード係数
	public const float shotSpeedCoefficient = 10.0f;
	public const int COLOR_TYPE_START = 1;

	// マテリアル
	private Rigidbody _rigidBody;
	public Material material;

	public enum ColorType
	{
		RED = COLOR_TYPE_START,
		BLUE,
		GREEN,
		YELLOW,
	}

	// バブルの色
	private int _bubbleColor = 0;

	/*
    * OnCollisionEnterより早く_rigidBodyを生成する 
	*/
	void Awake() {
		_rigidBody = gameObject.GetComponent<Rigidbody> ();
	}

	// Use this for initialization
	public virtual void Start ()
	{
//		shotBall ();
	
		setColor ();
//		setKinematic ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void shotBall (Transform centerOfRotate)
	{
		Vector3 vel = (transform.position - centerOfRotate.position) * shotSpeedCoefficient;
		_rigidBody.velocity = vel;
	}
	
	// 回転させる処理
	void rotateBall (Transform centerOfRotate)
	{
		// Y軸を中心に回す
//		Vector3 axis = transform.TransformDirection (Vector3.up);
		// Z軸を中心に回す（反時計回り）
//		Vector3 axis = transform.TransformDirection (Vector3.forward);
		// Z軸を中心に回す（時計回り）
		Vector3 axis = transform.TransformDirection (Vector3.back);
		transform.RotateAround (centerOfRotate.position, axis, rotateSpeed * Time.deltaTime);	
	}

	// 衝突時に呼ばれる
	void OnCollisionEnter (Collision col)
	{
		// バブルと衝突したら止める
		if (col.gameObject.CompareTag ("Bubble")) {
			// 自分を止める
//			http://www.happytrap.jp/blogs/2012/01/14/6719/
			_rigidBody.velocity = Vector3.zero;
			_rigidBody.angularVelocity = Vector3.zero;
		}
	}

	public void setColor (int color = COLOR_TYPE_START - 1)
	{
		if (color == COLOR_TYPE_START - 1) {
			// ランダムに決める
			_bubbleColor = Random.Range (COLOR_TYPE_START, System.Enum.GetValues (typeof(ColorType)).Length);
		} else {
			_bubbleColor = color;
		}

		Color c;
		switch (_bubbleColor) {
		case (int)(ColorType.RED):
			c = Color.red;
			break;
		case (int)(ColorType.BLUE):
			c = Color.blue;
			break;
		case (int)(ColorType.GREEN):
			c = Color.green;
			break;
		case (int)(ColorType.YELLOW):
			c = Color.yellow;
			break;
		default:
			throw new UnityException ("色が定義されていません // " + _bubbleColor);
		}
		GetComponent<Renderer> ().material.color = c;
	}

	public virtual void setKinematic(){
		_rigidBody.isKinematic = true;
	}
}
