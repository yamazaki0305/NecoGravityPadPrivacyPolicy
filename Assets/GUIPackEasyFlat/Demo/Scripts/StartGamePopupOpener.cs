// Copyright (C) 2015, 2016 ricimi - All rights reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement.
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms.

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Specialized version of the PopupOpener class that opens the StartGamePopup popup
// and sets an appropriate number of stars (that can be configured from within the
// editor).
public class StartGamePopupOpener : PopupOpener
{
	public int stage_no;
    public int starsObtained = 0;
	public Image ImgStar1,ImgStar2,ImgStar3;

    public override void OpenPopup()
    {
        var popup = Instantiate(popupPrefab) as GameObject;
        popup.SetActive(true);
        popup.transform.localScale = Vector3.zero;
        popup.transform.SetParent(m_canvas.transform, false);

        var startGamePopup = popup.GetComponent<StartGamePopup>();

        startGamePopup.Open();
        startGamePopup.SetAchievedStars(starsObtained);
    }

	public void Awake()
	{

		// SaveDataを開く
		SaveDataBase.loadData();

		starsObtained = DataBase.level_star [stage_no - 1];
		Debug.Log("level:"+stage_no + " star:"+starsObtained );

		ImgStar1.color = new Color (255 / 255f, 0 / 255f, 0 / 255f);
		ImgStar2.color = new Color (255 / 255f, 0 / 255f, 0 / 255f);
		ImgStar3.color = new Color (255 / 255f, 0 / 255f, 0 / 255f);
	
		for (int i = 0; i < 3; i++)
		{
			switch (i)
			{
				case 0:
					if ( 1 <= starsObtained ) {
						ImgStar1.color = new Color (254 / 255f, 207 / 255f, 88 / 255f);
					}
					else
						ImgStar1.color = new Color (0 / 255f, 0 / 255f, 0 / 255f, 70 / 255f);
				break;

				case 1:
					if ( 2 <= starsObtained ) {
						ImgStar2.color = new Color (254 / 255f, 207 / 255f, 88 / 255f);
					}
					else
						ImgStar2.color = new Color (0 / 255f, 0 / 255f, 0 / 255f, 70 / 255f);
				break;

				case 2:
					if ( 3 <= starsObtained ) {
						ImgStar3.color = new Color (254 / 255f, 207 / 255f, 88 / 255f);
					}
					else
						ImgStar3.color = new Color (0 / 255f, 0 / 255f, 0 / 255f, 70 / 255f);
				break;

			}
		}

	}

	public void stageselect()
	{
		DataBase.nowStage = stage_no;
		LoadStage.now_stage =  stage_no;
		Debug.Log ("stage名:" + DataBase.nowStage);
		SceneManager.LoadScene ("stage"+DataBase.nowStage );

	}

}
