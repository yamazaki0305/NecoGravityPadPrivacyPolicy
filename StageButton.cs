using UnityEngine;
using System.Collections;

public class StageButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void clickRetryButton() {

		Application.LoadLevel( Application.loadedLevelName );

	}

	public void clickNextButton() {

		DataBase.nowStage++;
		Debug.Log ("stage名:" + DataBase.nowStage);
		Application.LoadLevel( "stage"+DataBase.nowStage );

	}

}
