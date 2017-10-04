using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIA : MonoBehaviour {

	//public Vector2 move;
	public float x;
	public float y;
	public float posicion;
	public float cambiador;
	public Vector2 velocity;
	public Rigidbody2D rb2D;// Variable para que el Collide siga al sprite
	public GameObject Player;// Ubica al player
	public float vida;

	void Start () {
		x = -2.5f;
		cambiador = 0;
		//esto sirve para cambiar que el enemigo vallad e un lado al otro


		vida = 30;
		rb2D = GetComponent<Rigidbody2D>();
		Player = CharactersManager.GetInstance ().Player;
		posicion = transform.position.x;
	}

	void FixedUpdate()
	{
		velocity.x = 0.0f;
		velocity.y = rb2D.velocity.y;
		//collide siga al sprite
		//rb2D.MovePosition(rb2D.position + velocity * Time.fixedDeltaTime);
		rb2D.velocity = velocity;
	}

	void Update () {	


		transform.Translate (new Vector2 (x, 0) * Time.deltaTime);

		// Movimiento del personaje
		// Si el personaje esta cerca va a el

		if(Player.transform.position.x - transform.position.x < 5 &&
			Player.transform.position.x - transform.position.x > -5){

		if (Player.transform.position.x - transform.position.x < 5 && 
			Player.transform.position.x - transform.position.x > 1) {

				transform.rotation = Quaternion.Euler (new Vector2 (0, 180));
		}
		if (Player.transform.position.x - transform.position.x > -5 && 
			Player.transform.position.x - transform.position.x <-1){
			
			transform.rotation = Quaternion.Euler (new Vector2 (0, 0));
		}
		}

		// se mueve de un lado para el otro
		else {
			cambiador = posicion - transform.position.x;
			if (cambiador<-2) {
				transform.rotation = Quaternion.Euler (new Vector2 (0, 0));
			}
			if (cambiador>2) {
				transform.rotation = Quaternion.Euler (new Vector2 (0, 180));
			}
		}
			
		if (vida <= 0) {
			Destroy (gameObject);
		}

	}

	public void Damage(int damage){
		vida -= damage;
//		Debug.Log ("asdf");
//		if (Player.transform.position.x - transform.position.x < 5 &&
//			Player.transform.position.x - transform.position.x > 0) {
//			transform.rotation = Quaternion.Euler (new Vector2 (0, 180));
//			transform.Translate (new Vector2 (x, 0) * Time.deltaTime*-50);
//		}
//		if (Player.transform.position.x - transform.position.x > -5 &&
//			Player.transform.position.x - transform.position.x < 0) {
//			transform.rotation = Quaternion.Euler (new Vector2 (0, 0));
//			transform.Translate (new Vector2 (x, 0) * Time.deltaTime*-50);
//		}
	}

}