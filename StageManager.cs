using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StageManager : MonoBehaviour {

	static StageManager main;

	public int iClearFlag;

	public int STAR_COUNT;

	// ステージクリアObjの表示判定
	public GameObject bStageClearObj;
	// 取ったスターの数をテキスト表示
	public Text textStar;
	// ステージミスObjの表示判定
	public GameObject bStageMissObj;
	//ステージ数の表示設定
	public Text textStage;

	// Use this for initialization
	void Awake () {
		iClearFlag = DataBase.PLAY; 
		STAR_COUNT = 0;

		bStageClearObj.SetActive (false);
		bStageMissObj.SetActive (false);
		textStage.text = "STAGE " + DataBase.nowStage;
		main = this;

	}
	
	// Update is called once per frame
	void Update () {

		if (iClearFlag == DataBase.CLEAR) {
		
			textStar.text = "×" + STAR_COUNT;
			bStageClearObj.SetActive (true);
			bStageMissObj.SetActive (false);
		} else if (iClearFlag == DataBase.MISS) {
			bStageClearObj.SetActive (false);
			bStageMissObj.SetActive (true);
		}
	}

	public static StageManager getInstance()
	{
		return main;
	}

	public static int getClearFlag()
	{
		return main.iClearFlag;
	}
}
