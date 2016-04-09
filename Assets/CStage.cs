using UnityEngine;
using System.Collections;

public class CStage : MonoBehaviour
{

	// バブルのプレハブをここに代入
	public GameObject bubble;
	public GameObject stage;

	// Use this for initialization
	void Start ()
	{
		initializeArrange ();

	
	}

	private void initializeArrange ()
	{
//		Debug.Log(stage.transform.position);
//		Debug.Log(stage.transform.localPosition.x);
//		Debug.Log(stage.GetComponent<Renderer>());
		// ステージの柵の太さのバッファ
		float bufferWidth = 0.7f;
		float bufferHeight = 0.0f;
		float stageX = stage.transform.localPosition.x + bufferWidth;
		float stageY = stage.transform.localPosition.y + bufferHeight;
		float stageWidth = 14;

		Bounds bubbleBounds = bubble.GetComponent<MeshRenderer> ().bounds;
		float stageHeight = 9;
		float bubbleWidth = bubbleBounds.size.x;
		float bubbleHeight = bubbleBounds.size.y;
		// フィールドの上から左端らかstageWidth * stageHeight分敷き詰める
		for (float i = stageX; i < stageX + stageWidth; i += bubbleWidth) {
			for (float j = stageY; j < stageY + stageHeight; j += bubbleHeight) {
				makeCBubbleEnemy (i, j, 0);
			}

		}

	}

	private void initializeRandom ()
	{
		for (int i = 0; i < 10; i++) {

			// ゲーム開始時にボールを適当に配置
			//オブジェクトの座標
			float x = Random.Range (0.0f, 5.0f);
			// 近すぎたら回避
			while (-1 < x && x < 1) {
				x = Random.Range (0.0f, 5.0f);
			}
			float y = Random.Range (0.0f, 5.0f);
			while (-1 < y && y < 1) {
				y = Random.Range (0.0f, 5.0f);
			}
			float z = 0;
			makeCBubbleEnemy (x, y, z);
		}

	}

	private void makeCBubbleEnemy (float x, float y, float z)
	{
		//オブジェクトを生産
		GameObject b = (GameObject)Instantiate (bubble, new Vector3 (x, y, z), Quaternion.identity);
//			Instantiate (bubble, new Vector3 (x, y, z), Quaternion.identity);
		CBubbleEnemy cb = b.AddComponent<CBubbleEnemy> ();
		cb.setColor ();
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
