using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {
	public GameObject CurrentRoom;
	public GameObject DestinyRoom;
	public GameObject SpawnPoint;
	public GameObject Player;

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.tag == "Player") {
			collision.collider.gameObject.transform.position = SpawnPoint.transform.position;
			CurrentRoom.SetActive (false);
			DestinyRoom.SetActive (true);
		}

	}
}
