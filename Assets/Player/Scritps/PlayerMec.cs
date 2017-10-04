using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMec : MonoBehaviour {
	public Rigidbody2D player;
	public GameObject Yo;
    public bool canJump;
    public bool canWalk;
    public float speed = 0.2f;
    public float grav = 0.5f;
    public float hSpeed = 0;
    public float vSpeed = 0;
    public int counter = 0;
	public float playerY=0f;
	public Animator anim;
	public int reference=1;
	public float vida=52;
	public float vidaCD=2f;
	public bool vidaCDTimer=false;


	void Start () {
		player = GetComponent<Rigidbody2D> ();
	}
		
	void Update () {

        player.velocity = new Vector2(hSpeed, vSpeed);

		//Esto es para caminar derecha e izquierda y correr;
		if (Input.GetKey (KeyCode.D)) {
			transform.rotation = Quaternion.Euler (new Vector2 (0, 0));
			hSpeed += speed;
			if (Input.GetKey (KeyCode.LeftShift))
				hSpeed = 15;
			else
				hSpeed = 10;
		} else if (hSpeed > 0) {
			hSpeed -= speed * 4;
			if (hSpeed < 0)
				hSpeed = 0;
		}
		
		
		if (Input.GetKey (KeyCode.A)) {
			hSpeed -= speed;
			transform.rotation = Quaternion.Euler (new Vector2 (0, 180));
			if (Input.GetKey (KeyCode.LeftShift))
				hSpeed = -15;
			else
				hSpeed = -10;
		} else if (hSpeed < 0) {
			hSpeed += speed * 4;
			if (hSpeed > 0)
				hSpeed = 0;
		}
		

		//Saltar
		if (Input.GetKey(KeyCode.W) && counter == 1){
			vSpeed = 15;
			counter = 0;
		}
			
        RaycastHit2D hit;

		hit = Physics2D.BoxCast((Vector2)this.transform.position - new Vector2(0.0f, 0.65f), new Vector2(0.7f, 0.1f),
            0.0f, Vector2.down, 0.5f, LayerMask.GetMask("Floor"));
		
        if (hit.rigidbody == null || vSpeed > 0.0f){
            vSpeed -= grav;
        }
        else if (counter == 0 && hit.rigidbody != null){
            vSpeed = 0;
            counter = 1;
        }
		if (hit.rigidbody != null && vSpeed<0) {
			vSpeed = 0;
		}
        float move = Mathf.Abs(Input.GetAxis("Horizontal") * hSpeed);

        anim.SetFloat("Speed", move);

		if(vidaCDTimer==true){
			
			vidaCD += Time.deltaTime;
			if (vidaCD > 2)
				vidaCDTimer = false;
		}
		if (vida <= 0){
			///Destroy (gameObject);
			Yo.SetActive(false);
		}
    }
    // ACA QUERRIA QUE SI COLICIONA CON ALGUNO DE LOS ENEMIGOS MALOS LE SAQUEN VIDA
    void OnTriggerEnter2D(Collider2D colador)
    {
        if (LayerMask.LayerToName(colador.gameObject.layer) == "EnemyAttack")
        {

            if (vidaCD >= 2)
            {
                vida -= 10;
                vidaCD = 0;
                vidaCDTimer = true;

                /*RaycastHit2D pushL;

                pushL = Physics2D.BoxCast((Vector2)this.transform.position - new Vector2(0.65f, 0.0f), new Vector2(0.7f, 0.1f),
                    0.0f, Vector2.left, 0.5f, LayerMask.GetMask("EnemyAttack"));
                if (pushL.rigidbody == null)
                    hSpeed += 20;

                else
                {
                    RaycastHit2D pushR;

                    pushR = Physics2D.BoxCast((Vector2)this.transform.position - new Vector2(-0.65f, 0.0f), new Vector2(0.7f, 0.1f),
                        0.0f, Vector2.right, 0.5f, LayerMask.GetMask("EnemyAttack"));
                    if (pushR.rigidbody == null)
                        hSpeed -= 20;
                }*/
            }
	     }
	}
}
