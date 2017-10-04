using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defence : MonoBehaviour {

	private bool defece = false;
	private float defenceTimer = 0;
	private float defenceCD = 0.3f;
	public Collider2D DefenceD;
	public GameObject activadorAtaque;
	public GameObject defensaNow;

	void Awake(){
		//DefenceD.enabled = false;
		defensaNow.SetActive (false);
	}
	void Update (){




		if (Input.GetKeyDown (KeyCode.K) && !defece) {
			if (activadorAtaque.gameObject.activeSelf==false) {
				defece = true;
				defenceTimer = defenceCD;
				//DefenceD.enabled = true;
				defensaNow.SetActive (true);
			}
				
			
		}
		if (defece) {
			if (defenceTimer > 0) {
				defenceTimer -= Time.deltaTime;
			} 
			else {
				defece = false;
				//DefenceD.enabled = false;
				defensaNow.SetActive (false);
			}
		}
	}
}