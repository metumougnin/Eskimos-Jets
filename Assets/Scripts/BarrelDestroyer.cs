using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Permet de détruire un barril après la génération
public class BarrelDestroyer : MonoBehaviour {

	// Particule d'effet à afficher lors de la destruction
	public ParticleSystem explosionParticle;
	// Degats infligés par le barril au joueur
	public int barrelDamages = 70;

	// eviter de creer un particle effet à la destruction si le joueur n'est pas touché
	private bool isPlayerTouched = false;
	// Reference sur le joueur
	private Player playerRef;

	// Affectation des references
	void Awake(){
		playerRef = Player.FindObjectOfType<Player> ();
	}

	void Update () {
		// Detruire l'objet s'il sort de la zone de jeu et a une absisse inferieur ou egale à -20
		if(this.transform.position.y <= -20) {
			Destruction();
		}
	}

	// Detruire l'objet s'il sort de la zone de jeu et touche le sol de destruction
	void OnCollisionEnter(Collision coll) {
		if (coll.gameObject.name == "Destroyer Ground") {
			Destruction ();
		}

		//Si le missile touche le sol du jeu, il explose
		else if (coll.gameObject.tag == "Player") {
			// On active le booléen afin d'afficher l'effet de articule
			isPlayerTouched = true;
			Destruction ();
		}
	}



	// Methode de destruction
	void Destruction() {
		Destroy(this.gameObject);

		// Affecter la vie du joueur s'il est touché
		if (isPlayerTouched) {
			playerRef.TakeDamages(barrelDamages);
			Instantiate (explosionParticle, transform.position, transform.rotation);
		}

		// On desactive le booléen pour le prochain tour
		isPlayerTouched = false;
	}
}
