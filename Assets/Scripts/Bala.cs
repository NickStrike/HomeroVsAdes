using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour {
	float x;

	void Start () {
		x = -5.5f;
	}

	void Update () {
		transform.Translate (new Vector2 (x, 0) * Time.deltaTime);
	}
}
