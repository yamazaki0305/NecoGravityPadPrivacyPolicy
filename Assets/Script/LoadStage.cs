using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadStage : MonoBehaviour {

	public static int  now_stage = 1;

	// Use this for initialization
	void Awake () {
		
		DontDestroyOnLoad (gameObject);

	}
	
	public void clickRetryButton() {

		Application.LoadLevel( Application.loadedLevelName );

	}

	public void clickNextButton() {

		now_stage++;
		DataBase.nowStage++;
		Application.LoadLevel( "stage"+now_stage );

	}

	public void clickLevelButton() {

		SceneManager.LoadScene ("LevelScene");

	}

}
