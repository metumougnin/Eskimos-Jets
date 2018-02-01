using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Cette classe permet de détruire les bombes generées durant la partie
public class BombDestroyer : MonoBehaviour {

	// A REVOIR
	// Le nombe de points de vie a retirer qd une bombe explose avec le joueur dans les parages


	// Temps de vie maximal (en seconde) d'une bombe
	public float lifeTime = 10f;
	// Rayon de la zone de detection après l'explosion de la bombe
	public float explosionDetectionRadius = 5f;
	// Effet de particule à afficher lorque la bombe explose
	public ParticleSystem explosionParticle;
	// Nombre de points de vie à retirer au joueur s'il se trouve dans le rayon de l'explosion
	public int nearbyExplosionDamages = 10;

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
				Destruction();
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
		}
	}

	// Methode de destruction
	void Destruction() {
		// On instancie la particule d'effet quand la bombe est detruite
		Instantiate (explosionParticle, transform.position, transform.rotation);
		// On recupere tous les objets se trouvant dans le rayon de l'explosion
		Collider[] colliders = Physics.OverlapSphere (transform.position, explosionDetectionRadius);
		// Detruire la bombe
		Destroy(this.gameObject);

		// Affecter la vie du joueur s'il se trouve dans le rayon de l'explosion
		foreach(Collider nearbyObject in colliders){
			if (nearbyObject.gameObject.tag == "Player") {
				playerRef.TakeDamages(nearbyExplosionDamages);

				// A RETIRER
				Debug.Log ("[In BombDestruction Class]: Une bombe a touché le joueur");
			}
		}
	}
}