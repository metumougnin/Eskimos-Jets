using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Classe permettant de deplacer des objets à droite dans l'espace de jeu. 
public class MovingObjectsRight : MonoBehaviour {

	// La direction dans laquelle on veut que lde deplacement s'effectue
	protected Vector3 direction;

	// The speed at wich the object moves
	protected float speed;
	// Minimum speed value
	public float minSpeed;
	// Maximum speed value
	public float maxSpeed;

	// Use this for initialization
	void Start () {
		direction = Vector3.right;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		// On attribue une vitesse aléatoire et on applique la force sur l'objet
		speed = Random.Range(minSpeed, maxSpeed);
		GetComponent<Rigidbody> ().AddForce (direction * speed);
	}

	// On evite aux objets entrants en collision avec les mour lateraux, de quitter l'aire de jeu
	// S'il y a contact, on pousse l'objet dans le sens d'orientation opposé.
	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "Lateral Walls"){
			if (direction == Vector3.right)
				direction = Vector3.left;
			else
				direction = Vector3.right;
		}
	}
}
