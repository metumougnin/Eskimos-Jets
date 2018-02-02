using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Classe permettant de deplacer des objets à gauche
// dans l'espace de jeu. 
public class MovingObjectsLeft : MovingObjectsRight {

	// Use this for initialization
	void Start () {
		direction = Vector3.left;
	}

	// Update is called once per frame
	void Update () {
		
		// On attribue une vitesse aléatoire et on applique la force sur l'objet
		speed = Random.Range(minSpeed, maxSpeed);
		GetComponent<Rigidbody> ().AddForce (direction * speed, ForceMode.Force);

	}

	// On evite aux bombes de quitter l'aire de jeu
	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "Lateral Walls"){
			if (direction == Vector3.right)
				direction = Vector3.left;
			else
				direction = Vector3.right;
		}
	}


}
