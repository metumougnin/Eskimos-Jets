using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour {

	// Reference sur le joueur
	private Player playerRef;

	public int damages = 50;

	// Affectation des references
	void Awake(){
		playerRef = Player.FindObjectOfType<Player> ();
	}

	void OnTriggerEnter( Collider other ) {
		if (other.gameObject.tag == "Player") {	
			playerRef.TakeDamages(damages);
			Destroy (this.gameObject);
		}
	}
}
