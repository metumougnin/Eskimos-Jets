using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour {

	// Liste des objets à generer
	public GameObject[] spawnees;
	// Delai avant de debuter l'ensemble des générations
	public float spawnTime;
	// Delai entre chaque generation
	public float spawnDelay;

	public float lifeTime = 10f;

	public bool isOpen = false;

	public AudioClip chestPickup;

	public GameObject groundHitFX;
	public GameObject hitText;


	private PowerupsManager powerupsManager;

	//public Player p;

	private int randomObject;

	private Animator animator;
	private Rigidbody rigidBody;

	//private enum powerups {pill};

	void Awake() {
		animator = GetComponent<Animator> ();
		rigidBody = GetComponent<Rigidbody> ();
	}

	void Update() {
		//if(rigidBody.velocity.y == 0) {
		if(transform.position.y <= 1.75f) {
			animator.SetBool ("isGrounded", true);

			if (!isOpen) {
				isOpen = true;

				GameObject instance = CFX_SpawnSystem.GetNextObject(groundHitFX);
				GameObject instance2 = CFX_SpawnSystem.GetNextObject(hitText);
				Vector3 position = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
				Vector3 position2 = new Vector3 (transform.position.x, transform.position.y + 3f, transform.position.z - 3f);
				instance.transform.position = position;
				instance2.transform.position = position2;

				InvokeRepeating ("SpawnObject", spawnTime, spawnDelay);
			}
		}


		// Détruire l'objet si le temps de vie est ecoulé
		if(lifeTime > 0) {
			lifeTime -= Time.deltaTime;
			if(lifeTime <= 0) {
				Destruction();
			}
		}

	}

	public void SpawnObject() {
		Vector3 position = new Vector3 (transform.position.x, transform.position.y + 3f, transform.position.z);
		randomObject = Random.Range (0, spawnees.Length);
		GameObject generatedPowerup = Instantiate(spawnees[randomObject], position, Quaternion.identity) as GameObject;
		generatedPowerup.transform.parent = this.transform;

			CancelInvoke("SpawnObject");
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "Player") {
			//AudioSource.PlayClipAtPoint (chestPickup, );
			powerupsManager = GameObject.FindObjectOfType<PowerupsManager> ();
			switch (randomObject) {
			case 0:
				powerupsManager.Pill ();
				//p.AddHealth(10);
				//powerupsManager.pill = true;
				break;
			case 1:
				powerupsManager.Shield ();
				break;
			case 2:
				powerupsManager.AddJetpackEnergyDefaultValue();
				break;
			default:
				break;
			}

			Destruction ();
		}
	}

	// Methode de destruction
	void Destruction() {
		Destroy(this.gameObject);
	}
}
