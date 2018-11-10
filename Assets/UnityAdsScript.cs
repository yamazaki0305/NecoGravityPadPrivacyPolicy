using UnityEngine;
using System.Collections;
// ここの追加を忘れずに。
// 参考URL http://megumisoft.hatenablog.com/entry/2015/09/03/224409
using UnityEngine.Advertisements;

//https://docs.unity3d.com/ScriptReference/Advertisements.Advertisement.html

public class UnityAdsScript : MonoBehaviour {   

	[SerializeField]
	string zoneID = "rewardedVideo";
	[SerializeField]
	string gameID_iOS = "1260109";
	[SerializeField]
	string gameID_Android = "1260108";

	void Start ()
	{
		if (Advertisement.isSupported && !Advertisement.isInitialized) {
			#if UNITY_ANDROID
			Advertisement.Initialize(gameID_Android);
			#elif UNITY_IOS
			Advertisement.Initialize(gameID_iOS);
			#endif
		}
	}
	/*
	void Awake()
	{   
		// まずはAwake()内で、初期化をします。先ほどのゲームIDを入力。
		Advertisement.Initialize ("133032");
	}
	*/

	public void ShowAd() {
		// 広告再生の準備ができているか確認。
		if ( Advertisement.IsReady() ) 
			// 準備ができていたら、広告再生。
			Advertisement.Show();
	}

	public void ShowUnityAds ()
	{
		#if UNITY_ANDROID || UNITY_IOS
		if (Advertisement.IsReady( ) ) {
		//var options = new ShowOptions { resultCallback = HandleShowResult };
		Advertisement.Show( );
		}
		#endif
	}
}