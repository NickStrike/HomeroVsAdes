using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerroIA : MonoBehaviour {

	public float x;
	public float y;
	private float timerAtaque = 0f;
	public float cambiador;
	public float posicion;
	public Vector2 velocity;
	public Rigidbody2D rb2D;// Variable para que el Collide siga al sprite
	public GameObject Player;
	public float vida ;

	// Use this for initialization
	void Start () {
		x = -2.5f;
		rb2D = GetComponent<Rigidbody2D>();
		Player = CharactersManager.GetInstance ().Player;
		posicion = transform.position.x;

		vida = 30;
	}
	void FixedUpdate()
	{
		velocity.x = 0.0f;
		velocity.y = rb2D.velocity.y;
		rb2D.velocity = velocity;
	}

	void Update () {


		transform.Translate (new Vector2 (x, 0) * Time.deltaTime);


		// ES EL MISMO SCRIPT QUE "ENEMIGOIA" EXEPTO
		if (Player.transform.position.x - transform.position.x < 5 &&
		   Player.transform.position.x - transform.position.x > -5) {
			if (timerAtaque < 1)
			if (Player.transform.position.x - transform.position.x < 5 &&
			   Player.transform.position.x - transform.position.x > 0) {
				transform.rotation = Quaternion.Euler (new Vector2 (0, 180));
				//ESTO QUE ES EL SALTITO <3
				timerAtaque += Time.deltaTime;
				if (timerAtaque < 2)
					transform.Translate (new Vector2 (x, 2) * Time.deltaTime);
			}
			if (Player.transform.position.x - transform.position.x > -5 &&
			   Player.transform.position.x - transform.position.x < -0) {
				transform.rotation = Quaternion.Euler (new Vector2 (0, 0));
				timerAtaque += Time.deltaTime;
				if (timerAtaque < 2)
					transform.Translate (new Vector2 (x, 2) * Time.deltaTime);
			} 
		}
		
		else {
			cambiador = posicion - transform.position.x;
			timerAtaque = 0;
			if (cambiador<-2) {
				//esto lo manda para la izquierda
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

	}
}
