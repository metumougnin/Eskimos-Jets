using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// La classe qui permet de generer des barrils venant de gauche
public class BarrelSpawnerLeft : MonoBehaviour {

	// Prefab du barril
	public GameObject spawnee;
	// bolléen qui permet d'arreter la generation
	public bool stopSpawning = false;
	// Delai avant de debuter l'ensemble des générations
	public float spawnTime;
	// Delai entre chaque generation
	public float spawnDelay;

	public Player playerRef;
	Vector3 position;

	// Use this for initialization
	void Start () {
		// InvokeRepeating est une methode d'Unity qui permet d'appeler indefiniment une fonction
		InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
	}

	// Genere les objets grace à la methode Instanciate
	public void SpawnObject() {
		Instantiate(spawnee, transform.position, spawnee.transform.rotation);

		// On arrete la generation si le booleen est activé
		if(stopSpawning) {
			CancelInvoke("SpawnObject");
		}
	}
}
