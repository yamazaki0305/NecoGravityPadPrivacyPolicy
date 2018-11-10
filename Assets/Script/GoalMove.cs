using UnityEngine;
using System.Collections;

public class GoalMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D collision)
	{

		if (collision.gameObject.tag == "star") {
			Debug.Log ("スターだよ");
			Destroy (collision.gameObject);

			if ( StageManager.getInstance ().iClearFlag == DataBase.PLAY)
			{
				//StageManager.getInstance ().STAR_COUNT++;
				//StageManager.getInstance ().starup();
				StageManager.getInstance ().starup();

				Sound.main.PlaySound (3);
			}
		}
	}

	void OnCollisionEnter2D( Collision2D collision )
	{

		if (collision.gameObject.tag == "missbar") {
			Debug.Log ("ゲームオーバーだよ");
			Destroy (gameObject);

			if (StageManager.getInstance ().iClearFlag == DataBase.PLAY)
				StageManager.getInstance ().iClearFlag = DataBase.MISS;
		}
	}
}
