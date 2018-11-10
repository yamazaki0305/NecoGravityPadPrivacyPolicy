using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StageManager : MonoBehaviour {

	static StageManager main;

	public int iClearFlag;

	public int STAR_COUNT;

	// ステージクリアObjの表示判定
	public GameObject bStageClearObj;

	// ステージクリア演出Objの表示判定
	public GameObject bStageClearEfectObj;

	// プレイヤーの表示設定
	public GameObject bNekomaruObj;

	// 取ったスターの数をテキスト表示
	public Text textStar;
	// ステージミスObjの表示判定
	public GameObject bStageMissObj;
	//ステージ数の表示設定
	public Text textStage;

	//クリア時の星の表示
	public Image ImgStar1,ImgStar2,ImgStar3;


	// Use this for initialization
	void Awake () {

		// SaveDataを開く
		SaveDataBase.loadData();

		iClearFlag = DataBase.PLAY;
		//iClearFlag = 0; 

		this.STAR_COUNT = 0;

		this.bNekomaruObj.SetActive (true);
		this.bStageClearObj.SetActive (false);
		this.bStageClearEfectObj.SetActive (false);
		this.bStageMissObj.SetActive (false);

		//クリア時の星の表示（星を未取得の設定）
		ImgStar1.color = new Color (200 / 255f, 200 / 255f, 200 / 255f, 113 / 255f);
		ImgStar2.color = new Color (200 / 255f, 200 / 255f, 200 / 255f, 113 / 255f);
		ImgStar3.color = new Color (200 / 255f, 200 / 255f, 200 / 255f, 113 / 255f);

		textStage.text = "Level " + LoadStage.now_stage;

		main = this;

		Debug.Log ("LoadStage.nowStage:" + LoadStage.now_stage + "DataBase.nowStage:" + DataBase.nowStage + "openLevel:" + DataBase.openLevel );

	}
	
	// Update is called once per frame
	void Update () {

		if (iClearFlag == DataBase.CLEAR) {
			//Debug.Log ("game clear test");

			textStar.text = "×" + STAR_COUNT;
			bNekomaruObj.SetActive (false);
			bStageClearObj.SetActive (true);
			bStageClearEfectObj.SetActive (true);
			bStageMissObj.SetActive (false);

			//クリアの設定
			if (DataBase.nowStage == DataBase.openLevel) {
				Debug.Log ("クリアは同じレベルだよ");

				if( DataBase.openLevel < 10 )
					DataBase.openLevel++;
			}

			//レベルの星の数のレコード更新
			if (DataBase.level_star [DataBase.nowStage-1] < STAR_COUNT)
				DataBase.level_star [DataBase.nowStage-1] = STAR_COUNT;

			//繰り返し実行しないようにフラグを変える
			iClearFlag = DataBase.CLEAR_AFTER;

			// SaveDataを保存
			SaveDataBase.saveData();

		} else if (iClearFlag == DataBase.MISS) {
			Debug.Log ("game over test");

			bNekomaruObj.SetActive (false);
			bStageClearObj.SetActive (false);
			bStageClearEfectObj.SetActive (false);

			bStageMissObj.SetActive (true);
		}
	}

	public void starup()
	{
		STAR_COUNT++;

		switch( STAR_COUNT )
		{
			case 1:
				ImgStar1.color = new Color (254 / 255f, 207 / 255f, 88 / 255f);
			break;
			case 2:
				ImgStar2.color = new Color (254 / 255f, 207 / 255f, 88 / 255f);
			break;
			case 3:
				ImgStar3.color = new Color (254 / 255f, 207 / 255f, 88 / 255f);
			break;

		}

	}


	public static StageManager getInstance()
	{
		return main;
	}

	/*
	//使用しません（エラーになるので）
	public static int getClearFlag()
	{
		//return main.iClearFlag;
		return iClearFlag;
	
	}
	*/
}
