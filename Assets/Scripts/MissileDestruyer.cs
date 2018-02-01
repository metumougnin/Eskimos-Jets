using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// La classe permettant de détruire les missiles generés
public class MissileDestruyer : MonoBehaviour {

	// Effet de particule à afficher lorque le missile explose
	public ParticleSystem explosionParticle;
	// Rayon de la zone de detection après l'explosion du missile
	public float explosionDetectionRadius = 10f;
	// Degats infligés par un missile lorqu'il touche la joueur
	public int missileDamages = 70;
	// Degats infligés au joueur lorqu'il se trouve dans le rayon d'explosion d'un missile
	public int nearbyExplosionDamages = 20;

	// Reference sur le joueur
	private Player playerRef;
	// Booléeen qui indique si le joueur a été directement touché par le missile
	private bool isPlayerDamaged;

	// Affectation des References
	void Awake(){
		playerRef = Player.FindObjectOfType<Player> ();
	}

	void Update () {
		// Detruire l'objet s'il sort de la zone de jeu et a une 
		// absisse inferieur ou egale à -20
		if(this.transform.position.y <= -20) {
			Destruction();
		}
	}

	// Detruire le missile s'il sort de la zone de jeu et touch le sol de destruction
	// Detruire le missile s'il touche le sol
	// Detruire le missile s'il touche directement le joueur
	void OnCollisionEnter(Collision coll) {
		// Si le missile touche le sol de destruction
		if (coll.gameObject.name == "Destroyer Ground") {
			Destruction ();
		}
		//Si le missile touche le sol du jeu
		else if (coll.gameObject.name == "Ground"){
			Destruction ();
		}

		//Si le missile touche le sol du jeu
		else if (coll.gameObject.tag == "Player") {
			playerRef.TakeDamages (missileDamages);
			// On active la variable afin d'eviter que la joueur soit egalement affecté par les degats
			// dû sa presence dans le rayon d'explosion du missile.
			isPlayerDamaged = true;
			Destruction ();
		}
	}



	// Methode de destruction
	void Destruction() {
		// On instancie la particule d'effet quand le est detruit
		Instantiate (explosionParticle, transform.position, transform.rotation);
		// On recupere tous les objets se trouvant dans le rayon de l'explosion
		Collider[] colliders = Physics.OverlapSphere (transform.position, explosionDetectionRadius);
		// Detruire le missile
		Destroy(this.gameObject);

		// Affecter la vie du joueur s'il se trouve dans le rayon d'explosion du missile
		foreach(Collider nearbyObject in colliders){
			if (nearbyObject.gameObject.tag == "Player") {
				// Si le joueur n'a pas été directement touché par le missile, mais qu'il se trouve dans le rayon d'explosion
				if(!isPlayerDamaged){
					playerRef.TakeDamages(nearbyExplosionDamages);
				}
			}
		}

		// Reinitialisation du booléen à false pour le prochain tour.
		isPlayerDamaged = false;
	}
}
