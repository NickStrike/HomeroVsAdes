using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

	public GameObject CurrentRoom;
	public GameObject DestinyRoom;
	public GameObject SpawnPoint;
	public GameObject Player;
	
	void Update () {
		if (Input.GetKey (KeyCode.X)) { 
			Player.transform.position = SpawnPoint.transform.position;
			CurrentRoom.SetActive (false);
			DestinyRoom.SetActive (true);
		}
	}
	void OnCollisionEnter2D(Collision2D collision) {
		if (Input.GetKey (KeyCode.X)) {
			
		}
	}
}