using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersManager : MonoBehaviour 
{
	//Singleton
	public GameObject Player;
	public GameObject[] Esqueleto;
	public GameObject[] EspirutuFuego;
	public GameObject Bala;
	public GameObject[] Perro;
	public GameObject Portal;
	public GameObject Doors;
	public GameObject FollowPlayer;

	//public GameObject[] Enemies;

	private static CharactersManager instance = null;

	public static CharactersManager GetInstance()
	{
		if (instance == null)
			instance = FindObjectOfType<CharactersManager> ();

		return instance;
	}

	// Use this for initialization
	void Awake ()
	{
		instance = this;	
	}

}
