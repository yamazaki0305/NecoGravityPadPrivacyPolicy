using UnityEngine;
using System.Collections;

public class GoalMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D( Collision2D collision )
	{
		if (collision.gameObject.tag == "missbar") {
			Debug.Log ("ゲームオーバーだよ");
			Destroy (gameObject);

			if (StageManager.getClearFlag() == DataBase.PLAY)
				StageManager.getInstance ().iClearFlag = DataBase.MISS;
		}
	}
}
