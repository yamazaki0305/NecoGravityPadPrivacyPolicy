using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

	public GameObject[] level;
	public Text starsAll_text;

	// Use this for initialization
	void Awake () {
	
		// SaveDataを開く
		SaveDataBase.loadData();

		Debug.Log( "解放したレベル："+ DataBase.openLevel );

		for (int i = 0; i < 10; i++) {
			if (i < DataBase.openLevel)
				level [i].SetActive (true);
			else
				level [i].SetActive (false);

		}

		int star = 0;
		for (int i = 0; i < DataBase.openLevel; i++) 
		{
			star += DataBase.level_star [i];
		}

		starsAll_text.text = star +"/30";

	}
	
	// Update is called once per frame
	void Update (){


	
	}
}
