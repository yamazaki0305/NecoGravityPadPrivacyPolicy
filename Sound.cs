using UnityEngine;
using System.Collections;

//サウンドのクレジット表記
//http://pocket-se.info/rules/

public class Sound : MonoBehaviour {


    ///音楽ファイル 
    public AudioClip[] audios;
    ///音を鳴らすコンポーネント 
    AudioSource audiosource;

    ///外部呼出し可能にするためのstatic変数 
    public static Sound main ;
    
    void Start () {
		//自身を入れる
	    main = this;
	    //取得しておく
	    audiosource = GetComponent<AudioSource>();
	 }


    ///音を鳴らす 
    public void PlaySound(int no)
    {
		audiosource.clip = audios[no];
	    audiosource.Play();
	}

}

