using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspirituFuegoIA : MonoBehaviour
{

    public float x = 0f;
    public float y = 0f;
    public float posicionx;
    public float posiciony;
    public float cambiador;
    public int arranque;
    //	private float timerDisparo =0f;
    private float distanciaDesde = 0f;
    private float distanciaHasta = 5f;
    public Vector2 direccionTiro;
    public Vector2 velocity;
    public GameObject Player;
    private float vida;


    void Start()
    {
        y = 2;
        x = 3;
        Player = CharactersManager.GetInstance().Player;

        direccionTiro = transform.position - Player.transform.position;
        direccionTiro.Normalize();
        posicionx = transform.position.x;
        posiciony = transform.position.y;
        arranque = 1;
        vida = 15;
    }

    void Update()
    {

        if (arranque == 1)
        {
            transform.Translate(new Vector2(0, -y) * Time.deltaTime);
            if (cambiador > 2)
            {
                arranque = 0;
            }
        }
        if (arranque == 0)
        {
            transform.Translate(new Vector2(0, y) * Time.deltaTime);
            if (cambiador < -2)
            {
                arranque = 1;
            }
        }

        cambiador = posiciony - transform.position.y;

        //esta es la reaccion del bicho cuando el player esta cerca

        if (Player.transform.position.x - transform.position.x < distanciaHasta &&
           Player.transform.position.x - transform.position.x > -distanciaHasta)
        {

            if (Player.transform.position.x - transform.position.x < distanciaHasta &&
               Player.transform.position.x - transform.position.x > distanciaDesde)
            {
                transform.Translate(new Vector2(x, 0) * Time.deltaTime);
            }
            if (Player.transform.position.x - transform.position.x > -distanciaHasta &&
               Player.transform.position.x - transform.position.x < -distanciaDesde)
            {
                transform.Translate(new Vector2(-x, 0) * Time.deltaTime);
            }
        }
        if (vida <= 0)
        {
            Destroy(gameObject);
        }

    }
    public void Damage(int damage)
    {
        vida -= damage;
    }
}