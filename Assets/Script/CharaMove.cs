using UnityEngine;
using System.Collections;

// http://hitoikigame.com/blog-entry-697.html

public class CharaMove : MonoBehaviour {

	//アニメーション
	public Animator animeData;

	//public GameObject StageClearObj;
	public bool bStageClear;

	private Rigidbody2D characterRB;
	private float forceCoef;

	// Use this for initialization
	void Start () {
	
		bStageClear = false;
		//StageClearObj.SetActive (false);

		forceCoef = 0f;



	}
	
	// Update is called once per frame
	void Update () {


		if (StageManager.getInstance ().iClearFlag == DataBase.PLAY)
		{

			// 対象の Rigidbody を取得する.
			//characterRB = GetComponent<Rigidbody2D> ();
			Rigidbody2D rd = GetComponent<Rigidbody2D>();

			if (CharacterManager.getInstance ().bGravity == false) {
				/*
				characterRB.AddForce (Vector3.up * forceCoef);
				forceCoef = 3f;
				*/
				/*
				// 上昇させる場合.
				characterRB.AddForce (Vector3.up * forceCoef);
				if (forceCoef < 0.5) {
					forceCoef = 20;
					//characterRB.velocity = Vector3.zero;
					//characterRB.Sleep ();
					//characterRB.WakeUp ();
				}
				else if( forceCoef <= 2 )
					forceCoef = 2;
				else
					forceCoef += -2;					

				*/
				
				//rd.velocity = Vector3.zero;
				rd.gravityScale = -0.2f;

				animeData.SetBool ("gravity", true);

			} else
			{
				/*
				characterRB.AddForce (Vector3.up * forceCoef);
				forceCoef = -3f;
				*/
				/*
				// 上昇させる場合.
				characterRB.AddForce (Vector3.up * forceCoef);
				if (forceCoef > 0.5) {
					forceCoef = -20;
					//characterRB.velocity = Vector3.zero;
					//characterRB.Sleep ();
					//characterRB.WakeUp ();
				}
				else if( forceCoef >= 2 )
					forceCoef = -2f;
				else
					forceCoef += 2f;	
				*/

				//rd.velocity = Vector3.zero;
				rd.gravityScale = 0.2f;


				animeData.SetBool ("gravity", false);
		
			}
			Debug.Log ("force:" + forceCoef);
		}

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

		/*
		if (collision.gameObject.tag == "star") {
			Debug.Log ("スターだよ");
			Destroy (collision.gameObject);

			if ( StageManager.iClearFlag == DataBase.PLAY)
			{
				StageManager.getInstance ().STAR_COUNT++;
				Sound.main.PlaySound (3);
			}
		}
		*/

		if (collision.gameObject.tag == "nekokan") {
			Debug.Log ("クリアだよ");
			Sound.main.PlaySound (2);

			Destroy (collision.gameObject);

			if ( StageManager.getInstance ().iClearFlag == DataBase.PLAY )
				StageManager.getInstance ().iClearFlag = DataBase.CLEAR;

		}
		if (collision.gameObject.tag == "missbar") {
			Debug.Log ("ゲームオーバーだよ");
			//Destroy (this.gameObject);

			if (StageManager.getInstance ().iClearFlag == DataBase.PLAY)
			{
				StageManager.getInstance ().iClearFlag = DataBase.MISS;
				Debug.Log ("Missbar");
			}
		}

	}

}
