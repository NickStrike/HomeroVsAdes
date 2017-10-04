using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalRandom : MonoBehaviour {

	public GameObject CurrentRoom;
	public GameObject DestinyRoom1;
	public GameObject DestinyRoom2;
	public GameObject DestinyRoom3;

	public GameObject SpawnPoint1;
	public GameObject SpawnPoint2;
	public GameObject SpawnPoint3;
	public GameObject Player;

    int numero = 0;

    private void Start()
    {
        numero = Random.Range(1, 4);
    }

    void OnCollisionEnter2D(Collision2D collision)
	{
		
		if (collision.collider.tag == "Player") {


			if (numero == 1) {
				collision.collider.gameObject.transform.position = SpawnPoint1.transform.position;
				DestinyRoom1.SetActive (true);
			}
			if (numero == 2) {
				collision.collider.gameObject.transform.position = SpawnPoint2.transform.position;
				DestinyRoom2.SetActive (true);
			}
			if (numero == 3) {
				collision.collider.gameObject.transform.position = SpawnPoint3.transform.position;
				DestinyRoom3.SetActive (true);
			}

			CurrentRoom.SetActive (false);

		}
	}
}
