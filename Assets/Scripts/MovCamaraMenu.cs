using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovCamaraMenu : MonoBehaviour {

	public float x;
	public float cambiador;
	public float posicion;

	void Start () {
		x = -2.5f;
		posicion = transform.position.x;
	}

	void Update () {
		transform.Translate (new Vector2 (x, 0) * Time.deltaTime);
		
		cambiador = posicion - transform.position.x;
		if (cambiador<-10) {
			//esto lo manda para la izquierda
			x=-2.5f;
		}
		if (cambiador>10) {
			x=2.5f;
		}
	}
}
