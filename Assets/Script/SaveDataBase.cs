using UnityEngine;
using System.Collections;

public class SaveDataBase : MonoBehaviour {

	// セーブデータの情報など
	const string SAVE_OPEN_LEVEL = "SAVE_OPEN_LEVEL";
	const string SAVE_STAR_LEVEL = "SAVE_STAR_LEVEL";

	public static void saveData()
	{

		int level = DataBase.openLevel;

		//********** 開始 **********//
		PlayerPrefs.SetInt(SAVE_OPEN_LEVEL, level );
		PlayerPrefs.Save();

		string str = DataBase.level_star [0].ToString() + DataBase.level_star [1].ToString() + DataBase.level_star [2].ToString() + DataBase.level_star [3].ToString() + DataBase.level_star [4].ToString() + DataBase.level_star [5].ToString() + DataBase.level_star [6].ToString() +DataBase.level_star [7].ToString() + DataBase.level_star [8].ToString() + DataBase.level_star [9].ToString();
		PlayerPrefs.SetString(SAVE_STAR_LEVEL, str );
		PlayerPrefs.Save();
		//********** 終了 **********// 

		//int iii = int.Parse(str);

		// 必要な変数を宣言する
		string stTarget = "987654321";

		// stTarget を Char 型の 1 次元配列に変換する
		char[] chArray1 = stTarget.ToCharArray();

		Debug.Log ("ああsave_string:" + chArray1[0] );

		int iii = int.Parse(chArray1[0].ToString());

		Debug.Log ("いいsave_string:" + iii );
	
	}

	public static void loadData()
	{
		if( PlayerPrefs.HasKey(SAVE_OPEN_LEVEL) )
		{
			DataBase.openLevel = PlayerPrefs.GetInt(SAVE_OPEN_LEVEL);
		
		}
		if( PlayerPrefs.HasKey(SAVE_STAR_LEVEL) )
		{
			string stTarget  = PlayerPrefs.GetString(SAVE_STAR_LEVEL);
			// stTarget を Char 型の 1 次元配列に変換する
			char[] chArray1 = stTarget.ToCharArray();

			for (int i = 0; i < 10; i++) {
				DataBase.level_star[i] = int.Parse(chArray1[i].ToString() );
			}

		}
	}
}
