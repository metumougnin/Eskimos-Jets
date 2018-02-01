using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Cette classe permet de Détruire un objet du jeu
public class Destroyer : MonoBehaviour {

	// Temps de vie maximal (en seconde) de l'objet
	public float lifeTime = 10f;

	// Update is called once per frame
	void Update () {
		// Détruire l'objet si le temps de vie est ecoulé
		if(lifeTime > 0) {
			lifeTime -= Time.deltaTime;
			if(lifeTime <= 0) {
				Destruction();
			}
		}

		// Detruire l'objet s'il sort de la zone de jeu et a une 
		// absisse inferieur ou egale à -20
		if(this.transform.position.y <= -20) {
			Destruction();
		}
	}

	// Detruire l'objet s'il sort de la zone de jeu et touche
	// le sol de destruction
	void OnCollisionEnter(Collision coll) {
		if(coll.gameObject.name == "Destroyer Ground") {
			Destruction();
		}
	}

	// Methode de destruction
	void Destruction() {
		Destroy(this.gameObject);
	}
}