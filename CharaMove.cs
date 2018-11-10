using UnityEngine;
using System.Collections;

public class CharaMove : MonoBehaviour {

	//public GameObject StageClearObj;
	public bool bStageClear;

	// Use this for initialization
	void Start () {
	
		bStageClear = false;
		//StageClearObj.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		Rigidbody2D rd = GetComponent<Rigidbody2D>();

		if (StageManager.getClearFlag() == DataBase.PLAY)
		{
			if (CharacterManager.getInstance ().bGravity == false) {
				rd.gravityScale = -0.2f;
				//Debug.Log ("重力逆にするよ");
			} else
				rd.gravityScale = 0.2f;
		}

	}

	void OnCollisionEnter2D( Collision2D collision )
	{

		if (collision.gameObject.tag == "star") {
			Debug.Log ("スターだよ");
			Destroy (collision.gameObject);

			if (StageManager.getClearFlag () == DataBase.PLAY)
			{
				StageManager.getInstance ().STAR_COUNT++;
				Sound.main.PlaySound (3);
			}
		}
		if (collision.gameObject.tag == "nekokan") {
			Debug.Log ("クリアだよ");
			Sound.main.PlaySound (2);

			Destroy (collision.gameObject);
			if (StageManager.getClearFlag() == DataBase.PLAY )
				StageManager.getInstance ().iClearFlag = DataBase.CLEAR;

		}
		if (collision.gameObject.tag == "missbar") {
			Debug.Log ("ゲームオーバーだよ");
			Destroy (gameObject);
			if (StageManager.getClearFlag() == DataBase.PLAY )
				StageManager.getInstance ().iClearFlag = DataBase.MISS;
		}

	}

}
