using UnityEngine;
using System.Collections;

public class sidemoveBlock : MonoBehaviour {

	public bool fistMoveLeft;

	static int LEFT = -1;
	static int RIGHT = 1;

	int iMove;
	Vector3 point;

	// Use this for initialization
	void Start () {

		if (fistMoveLeft == true ) {
			iMove = LEFT;
		} else
			iMove = RIGHT;
	
		point = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		float disX = transform.position.x - point.x;

		if (disX > 4 || disX < -4) {
			iMove = -iMove;
			point = transform.position;
		}

		iTween.MoveAdd (gameObject, iTween.Hash ("x", 4*iMove, "time", 3f,
				"easetype", iTween.EaseType.linear, "islocal", true));

	}
}
