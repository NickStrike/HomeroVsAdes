using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class FollowPlayer : MonoBehaviour {
	public GameObject Player;

	void Start () {
	
	}


	void Update (){
		Vector3 pos = Player.transform.position;
		Vector3 diffCam = pos - this.transform.position;

		if (Mathf.Abs (diffCam.x) > 5.0f) {
			Vector3 newPos = this.transform.position;

			if (diffCam.x > 0.0f)
				newPos.x += diffCam.x - 5.0f;
			else
				newPos.x += diffCam.x + 5.0f;

			transform.position = newPos;
		}
		//pos.z = -20;
		//transform.position = pos;
	}
}
