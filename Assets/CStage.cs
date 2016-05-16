using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CStage : MonoBehaviour
{

	// バブルのプレハブをここに代入
	public GameObject bubble;
	public GameObject stage;
	
	public List<CBall>[] bubbleListMap;

	// Use this for initialization
	void Start ()
	{
		// bubbleListMapの初期化
		// TODO CBallのCOlorTypeの数をとってきたい
		bubbleListMap = new List<CBall>[6];
		for (int i = 0; i < 6; i++)
		{
			bubbleListMap[i] = new List<CBall>();
		}
	
		// ボール配置
		initializeArrange ();

	
	}

	private void initializeArrange (){

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
		cb.setStage(this);
		
		// bubbleListMapに情報を保存しておく
		bubbleListMap[cb.getColor()].Add(cb);
		
	}
	
	/**
	* バブルのチェイン数を更新する
	*/
	public int updateBubblesChainCount(int bubbleColor){
		List<CBall> targetList = bubbleListMap[bubbleColor];
		
		for (int i = 0; i < targetList.Count; i++)
		{
			int chainCount = getBubbleChainCount(targetList[i]);
			if (chainCount >= 2){
			// 削除する
				
			}
		}
		return 0;
	}
	
//	public int getBubbleChainCount(CBall bubble){
//		if (bubble.chainCount == CBall.SEARCH_CHAIN_COUNT_NOW){
//			// 調査中のものは無視する
//			return 0;
//		}
//		List<CBall> targetList = bubbleListMap[bubble.getColor()];
//		// 調査中フラグをつける
//		bubble.chainCount = CBall.SEARCH_CHAIN_COUNT_NOW;
//		int result = 0;
//		for (int i = 0; i < targetList.Count; i++)
//		{
//			// 自分はスルー
////			if (System.Object.ReferenceEquals(bubble, targetList[i]){
////			    continue;
////			}
//
//			// 接しているか判定
//
//			// 接していたら結果を追加
//			result += getBubbleChainCount(targetList[i]);
//		}
//		bubble.chainCount = result;
//		return result;
//	}
public void addBubbleToGroup(){
}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
