using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : MonoBehaviour {

	// Temps de vie maximal (en seconde) d'une bombe
	public float lifeTime = 10f;

	// Reference sur le joueur
	private Player playerRef;

	// Affectation des references
	void Awake(){
		playerRef = Player.FindObjectOfType<Player> ();
	}

	// Update is called once per frame
	void Update () {
		// Détruire l'objet si le temps de vie est ecoulé
		if(lifeTime > 0) {
			lifeTime -= Time.deltaTime;
			if(lifeTime <= 0) {
				DestructionWithFX();
			}
		}

		// Detruire l'objet s'il sort de la zone de jeu et a une absisse inferieur ou egale à -20
		if(this.transform.position.y <= -20) {
			Destruction();
		}
	}

	// Detruire l'objet s'il sort de la zone de jeu et touche le sol de destruction
	void OnCollisionEnter(Collision coll) {
		if(coll.gameObject.name == "Destroyer Ground") {
			Destruction();
		} else if( coll.gameObject.tag == "Player" ) {
			// TODO
			Debug.Log("Poison touched the player");
			playerRef.isPoisoned = true;
			Destruction ();
		}
	}


	// Methode de destruction
	void DestructionWithFX() {
		//TODO some FX before destruction
		Destroy (this.gameObject);
	}

	// Methode de destruction
	void Destruction() {
		Destroy (this.gameObject);
	}
}
