using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementsTutorial : MonoBehaviour {

	// The speed at which the player can move
	public float movementSpeed;
	// The max height at which the player can jump
	public float jumpHeight;



	// stores the horizontal axis at which the player moves
	public float horizontalAxis;
	// simulate left and right horizontal axis based on touch screen //
	private Vector3 leftHorizontalAxis;
	private Vector3 rightHorizontalAxis;
	//stores the movements informations
	private Vector3 movementDirection;
	//reference to the rigidbody attached to the player
	private Rigidbody rigidBody;
	// Permet de stocker et retrouver la vitesse normale du joueur après un saut
	private float tmpSpeed;
	//
	public bool isRunning;

	// POUR TEST JETPACK
	//public bool isJetPackEnabled = false;

	public Camera cameraRef; 

	//public PowerupsManager powerupsManager;
	private PlayerTutorial playerRef;



	// Use this for initialization
	void Start () {
		leftHorizontalAxis = Vector3.left;
		rightHorizontalAxis = Vector3.right;
		isRunning = false;
	}

	// Affectation des references
	void Awake(){
		rigidBody = GetComponent<Rigidbody> ();
		playerRef = GetComponent<PlayerTutorial> ();
	}



	// Update is called once per frame
	void FixedUpdate () {
		if( GetComponent<PlayerTutorial>().isPoisoned == false ) {
			// movements based on keyboard inputs
			if (Input.touchCount == 0) {
				// Deplacement Horizontal
				horizontalAxis = Input.GetAxis ("Horizontal");
				movementDirection = new Vector3 (horizontalAxis, 0, 0);

				// Saut
				if(Input.GetKey(KeyCode.UpArrow)){
					Jump ();
				}
			}

			// Movements based on touchscreen
			else { 
				if (Input.GetTouch (0).tapCount == 1) {

					horizontalAxis = 0f;

					// Deplacement Horizontal
					// Si on appuie la partie gauche de l'ecran, on se deplace à gauche
					// Si on appuie la partie droite de l'écran, on se déplace à droite
					if (Input.GetTouch (0).position.x < (Screen.width / 2)) {
						movementDirection = leftHorizontalAxis;
						horizontalAxis = -1f;
					} else if (Input.GetTouch (0).position.x > (Screen.width / 2)) {
						movementDirection = rightHorizontalAxis;
						horizontalAxis = 1f;
					} 

					// Si on touche la partie superieur de l'ecran, on saute
					if (Input.GetTouch (0).position.y > (Screen.height / 2)) {
						Jump ();
						// On annule le vecteur de direction afin d'eviter que le joueur se deplace
						// automatiquement à l'horizontale pendant le saut.
						horizontalAxis = 0f;
						movementDirection = new Vector3 (0, 0, 0);
					}

				}
			}

			//TODO: GERER LE COMPORTEMENT des ANIMS POUR MOBILE

			// Create a boolean that is true if either of the input axes is non-zero.
			isRunning = /*(Input.GetTouch (0).position.x != 0f) || */ (horizontalAxis != 0);




			// On stocke la vitesse normale de deplacement dans une variable temporaire
			// si on contate que le joueur a effectué un saut, on divise par 3 sa vitesse de deplacement
			tmpSpeed = movementSpeed;
			if (rigidBody.velocity.y != 0) {
				movementSpeed /= 3;
			}

			// Deplacer le joueur
			movementDirection = movementDirection * Time.deltaTime * movementSpeed;
			rigidBody.MovePosition (transform.position + movementDirection);

			// Remetrre la valeur initiale de la vitesse de deplacement
			movementSpeed = tmpSpeed;
		}
	}

	// Fonction qui gere le saut du joueur
	void Jump(){
		if (!playerRef.isJetPackEnabled) {
			if (rigidBody.velocity.y == 0) {
				rigidBody.velocity = Vector3.up * jumpHeight;
			}
		} else {
			// check the max y of the player
			if (transform.position.y < 18)
				rigidBody.velocity = Vector3.up * (jumpHeight / 2);
			playerRef.JetpackEnergyReduce ();
			cameraRef.GetComponent<CameraShaker> ().shouldShake = true;
		}
	}

}
