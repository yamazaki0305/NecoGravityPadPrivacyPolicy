using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class CharacterManager : MonoBehaviour {

	public bool bGravity;

	static CharacterManager main;

	// Use this for initialization
	void Awake () {

		bGravity = true;
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
			} else {
				Sound.main.PlaySound (1);
				bGravity = true;
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

