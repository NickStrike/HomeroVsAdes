using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col){
		if (col.isTrigger != true && LayerMask.LayerToName (col.gameObject.layer) == "Perro") {
			PerroIA enemyP = col.GetComponent<PerroIA> ();
			enemyP.Damage (10);
		}
		if (col.isTrigger != true && LayerMask.LayerToName (col.gameObject.layer) == "Esqueleto") {
			EnemyIA enemy = col.GetComponent<EnemyIA> ();
			enemy.Damage (10);
		}
        if (col.isTrigger != true && LayerMask.LayerToName(col.gameObject.layer) == "Boss")
        {
            Boss enemyB = col.GetComponent<Boss>();
            enemyB.Damage(10);
        }
        if (col.isTrigger != true && LayerMask.LayerToName(col.gameObject.layer) == "Abeja")
        {
            EspirituFuegoIA enemyA = col.GetComponent<EspirituFuegoIA>();
            enemyA.Damage(10);
        }
    }
}