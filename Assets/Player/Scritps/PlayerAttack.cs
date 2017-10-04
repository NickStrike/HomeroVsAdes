using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

	private bool attacking = false;
	private float attackTimer=0;
	private float attackCD=0.3f;//CD= cool dw 
	public Collider2D Attack;
	public GameObject activadorDefensa;
	public GameObject ataqueNow;

	void Awake(){
		ataqueNow.SetActive (false);
	}
	void Update (){
		
	/*	if (GameObject.Find (activadorDefensa.name) == null) {
			Debug.Log ("estoy defendiendo");
		}*/

		if (Input.GetKeyDown (KeyCode.J) && !attacking) {
			if (activadorDefensa.gameObject.activeSelf == false) {
				attacking = true;
				attackTimer = attackCD;
			ataqueNow.SetActive (true);
			}
		}
	
		if (attacking) {
			if (attackTimer > 0) {
				attackTimer -= Time.deltaTime;
			} 
			else {
				attacking = false;
				ataqueNow.SetActive (false);
			}
		}
	}

}
