using UnityEngine;
using System.Collections;
[System.Serializable]
public class CBall : MonoBehaviour
{

	//	http://am1tanaka.hatenablog.com/entry/20111109/1320846783
	public float INIT_DEGREE = 75f;
	public float INIT_SPEED = 0.000001f;

	// 回転の中心になるオブジェクト
	//	public Transform centerOfRotate;
	// 回転のスピード
	public const float rotateSpeed = 50.0f;

	// 射出の際のスピード係数
	public const float shotSpeedCoefficient = 20.0f;
	public const int COLOR_TYPE_START = 1;

	// マテリアル
	private Rigidbody _rigidBody;
	public Material material;

	private CPlayer battery = null;

	public enum ColorType
	{
		RED = COLOR_TYPE_START,
		BLUE,
		GREEN,
		YELLOW,
	}

	// バブルの色
	private int _bubbleColor = 0;

	public int groupNumber = 0;
//
//	// 検索中フラグ
//	public const int SEARCH_CHAIN_COUNT_INIT = -1;
//	// 検索中フラグ
//	public const int SEARCH_CHAIN_COUNT_NOW = -2;
//	// 削除中フラグ
//	public const int SEARCH_CHAIN_COUNT_DELETE = -3;


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
			if (battery != null){
				battery.stopPlayerBall ();
			}
			Debug.Log (CStage.Instance.GetInstanceID ());
			// 相手と色が同じだったら
			CBall other = (col.gameObject.GetComponent<CBall> ());
			int otherColor = other.getColor ();
			if (otherColor == _bubbleColor){
			// 同じグループに入れる
			}
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

	public void setBattery(CPlayer target){
		battery = target;
	}

	public int getColor(){
		return _bubbleColor;
	}
}
