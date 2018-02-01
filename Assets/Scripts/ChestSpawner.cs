using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSpawner : MonoBehaviour {

	// Liste des objets à generer
	public GameObject spawnee;
	// bolléen qui permet d'arreter la generation
	public bool stopSpawning = false;
	// Delai avant de debuter l'ensemble des générations
	public float spawnTime;
	// Delai entre chaque generation
	public float spawnDelay;

	public Player playerRef;
	Vector3 position;

	public float lifeTime = 10f;

	private GameObject spawn;

	// Use this for initialization
	void Start () {
		// InvokeRepeating est une methode d'Unity qui permet d'appeler indefiniment une fonction
		InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
	}

	// Genere les objets grace à la methode Instanciate
	public void SpawnObject() {
		position = new Vector3 (Random.Range(2f, 40f), 25f, playerRef.transform.position.z);
		spawn =  Instantiate(spawnee, position, spawnee.transform.rotation) as GameObject;


		// On arrete la generation si le booleen est activé
		if(stopSpawning) {
			CancelInvoke("SpawnObject");
		}
	}

	/*
	void Update() {
		// Détruire l'objet si le temps de vie est ecoulé
		if(lifeTime > 0) {
			lifeTime -= Time.deltaTime;
			if(lifeTime <= 0) {
				Destroy(spawn);
			}
		}
	}
	*/
}