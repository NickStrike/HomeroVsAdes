using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {

	public float x;
	public float y;
	private float timerBala;
	private float timerNum;
	public float cambiador;
	public float posicion;
	public Vector2 velocity;
	public Rigidbody2D rb2D;// Variable para que el Collide siga al sprite
	public GameObject Player;
	public float vida ;
	float timer;
	public GameObject Bala1;
	public GameObject Bala2;
	public GameObject Bala3;
	public GameObject Bala4;
	public GameObject Bala5;
	int numero;
	private bool acept; 

	int num=1;
	// Use this for initialization
	void Start () {
		acept = true;
		x = -2.5f;
		rb2D = GetComponent<Rigidbody2D>();
		Player = CharactersManager.GetInstance ().Player;
		posicion = transform.position.x;
		numero = Random.Range (1, 3);
		vida = 199.9f;
		Bala1.SetActive (false);
		Bala2.SetActive (false);
		Bala3.SetActive (false);
		Bala4.SetActive (false);
		Bala5.SetActive (false);
	}
	void FixedUpdate()
	{
		velocity.x = 0.0f;
		velocity.y = rb2D.velocity.y;
		rb2D.velocity = velocity;
	}

	void Update () {
		timerNum += Time.deltaTime;
		if (timerNum >= 7) {
			numero = Random.Range (1, 3);
			timerNum=0;
            timer = 0;
            timerBala = 0;
        }

		cambiador = posicion - transform.position.x;
		if (numero != 1 && cambiador>1) {
			timerNum = 0;
				transform.Translate (new Vector2 (x, 0) * Time.deltaTime*4);
				transform.rotation = Quaternion.Euler (new Vector2 (0, 180));
		}
		if (numero != 1 && cambiador < 1 && cambiador >-1) {
			acept = true;
		}	

		if(numero==1) {
			transform.Translate (new Vector2 (x, 0) * Time.deltaTime*4);
			if (cambiador<0) {
				//esto lo manda para la izquierda
				transform.rotation = Quaternion.Euler (new Vector2 (0, 0));
			}
			if (cambiador>20) {
				transform.rotation = Quaternion.Euler (new Vector2 (0, 180));
			}
			acept = false;
		}
		Debug.Log (numero);



		if (numero == 2 && acept==true) {
			transform.rotation = Quaternion.Euler (new Vector2 (0, 0));
			timer += Time.deltaTime;
			timerBala += Time.deltaTime;
			Bala1.SetActive (true);
			if(timerBala>4)
				Bala1.SetActive (false);

			if (timer > 1)
				Bala2.SetActive (true);
			if(timerBala>5)
				Bala2.SetActive (false);

			if (timer > 2)
				Bala3.SetActive (true);
			if(timerBala>6)
				Bala3.SetActive (false);
			
			if (timer > 3)
				Bala4.SetActive (true);
			if(timerBala>7)
				Bala4.SetActive (false);
			
			if (timer > 4)
				Bala5.SetActive (true);
			if(timerBala>8)
				Bala5.SetActive (false);

		}




		if (vida <= 0) {
			Destroy (gameObject);
		}
	}
	public void Damage(int damage){
		vida -= damage;

	}
}
