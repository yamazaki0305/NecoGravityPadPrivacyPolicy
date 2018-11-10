using UnityEngine;
using System.Collections;

public class MissBar : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D( Collision2D collision )
	{
		if (collision.gameObject.tag == "obstacle") {
			Destroy (collision.gameObject.gameObject);

			//if (StageManager.getInstance ().iClearFlag == DataBase.PLAY)
			//	StageManager.getInstance ().iClearFlag = DataBase.MISS;
		}
	}
}
