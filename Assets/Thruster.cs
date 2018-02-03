using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Thruster: Applique une force opposée au deplacement du joueur si celui entre en collision
/// avec l'objet
/// </summary>
public class Thruster : MonoBehaviour {

	// Permet d'indiquer dans quelle direction la force doit etre appliquee
	public bool leftForce = false;
	public bool rightForce = false;

	private bool flag = false;

	private Player playerRef;

	// Puissance de la force à appliquer
	public int power = 20;


	void Awake() {
		playerRef = GameObject.FindObjectOfType<Player> ();
	}


	void FixedUpdate() {
		if (flag) {
			// direction de la force à appliquer
			Vector3 direction = Vector3.zero;
			if (leftForce) {
				direction = Vector3.left;
			} else if (rightForce) {
				direction = Vector3.right;
			}

			playerRef.GetComponent<Rigidbody> ().AddForce (direction * power, ForceMode.Impulse);

			flag = false;
		}

	}

	void OnCollisionEnter( Collision other ) {
		if( other.gameObject.tag == "Player" ){
			flag = true;
		}
	}
}
