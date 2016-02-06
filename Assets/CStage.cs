using UnityEngine;
using System.Collections;

public class CStage : MonoBehaviour
{

	// バブルのプレハブをここに代入
	public GameObject bubble;

	// Use this for initialization
	void Start ()
	{

		for (int i = 0; i < 10; i++) {

			// ゲーム開始時にボールを適当に配置
			//オブジェクトの座標
			float x = Random.Range (0.0f, 5.0f);
			// 近すぎたら回避
			while ( -1 < x && x < 1){
				x = Random.Range (0.0f, 5.0f);
			}
			float y = Random.Range (0.0f, 5.0f);
			while ( -1 < y && y < 1){
				y = Random.Range (0.0f, 5.0f);
			}
			float z = 0;

			//オブジェクトを生産
			GameObject b = (GameObject)Instantiate (bubble, new Vector3 (x, y, z), Quaternion.identity);
//			Instantiate (bubble, new Vector3 (x, y, z), Quaternion.identity);
			CBubbleEnemy cb = b.AddComponent<CBubbleEnemy> ();
			cb.setColor ();
		}
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
