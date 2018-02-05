using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateSpawner : MonoBehaviour {

	// Objet à generer
	public GameObject spawnee;
	// booléen qui permet d'arreter la generation
	public bool stopSpawning = false;
	// Delai avant de debuter l'ensemble des générations
	public float spawnTime;
	// Delai entre chaque generation
	public float spawnDelay;

	private Player playerRef;
	Vector3 position;

	//public float lifeTime = 5f;

	private GameObject spawn;

	void Awake() {
		playerRef = Player.FindObjectOfType<Player> ();
	}

	// Use this for initialization
	void Start () {
		// InvokeRepeating est une methode d'Unity qui permet d'appeler indefiniment une fonction
		InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
	}

	// Genere les objets grace à la methode Instanciate
	public void SpawnObject() {
		position = new Vector3 (Random.Range(4f, 38f), 25f, playerRef.transform.position.z);
		Instantiate(spawnee, position, spawnee.transform.rotation);


		// On arrete la generation si le booleen est activé
		if(stopSpawning) {
			CancelInvoke("SpawnObject");
		}
	}
}
