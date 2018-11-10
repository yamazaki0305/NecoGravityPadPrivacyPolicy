using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour {

	void Start () 
	{
	}

	///ボタンを押したとき 
	public void GameStartButton()
	{
		Application.LoadLevel("stage1");
	}

}

