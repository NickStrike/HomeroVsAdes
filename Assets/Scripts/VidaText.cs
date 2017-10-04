using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaText : MonoBehaviour {
    public PlayerMec player;
    public Text textField;

    float lastVida;

	// Use this for initialization
	void Start () { 
        lastVida = player.vida;
        textField.text = "Vida: " + player.vida;
    }
     
    // Update is called once per frame 
    void Update () {
        if (lastVida != player.vida)
        {
            textField.text = "Vida: " + player.vida;
            lastVida = player.vida;
        }
	}
}
