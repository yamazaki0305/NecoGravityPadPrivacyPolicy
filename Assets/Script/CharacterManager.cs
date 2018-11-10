using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class CharacterManager : MonoBehaviour {

	public bool bGravity;
	public float iHanten;

	static CharacterManager main;

	// Use this for initialization
	void Awake () {

		bGravity = true;
		iHanten = 0f; //未使用
		main = this;

	}
	
	// Update is called once per frame
	void Update () {

		touchCheck();
	
	}

	void touchCheck()
	{

		if (Input.GetMouseButtonDown (0)) 
		{
			
			// 重力を逆にする
			if (bGravity == true) {
				Sound.main.PlaySound (0);
				bGravity = false;
				iHanten = -20;
			} else {
				Sound.main.PlaySound (1);
				bGravity = true;
				iHanten = 20;
			}
		}
	}

	public static CharacterManager getInstance()
	{
		return main;
	}

	public static bool getGravity()
	{
		return main.bGravity;
	}
}

