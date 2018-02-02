using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Bombs random timed spawner: Permet de generer aléatoirement des bombes à une cadence regulière
/// </summary> 
public class BombsRandomTimedSpawner : MonoBehaviour {

	// Liste des bombes à generer
	public GameObject[] spawnees;
	// booléen qui permet d'arreter la generation
	public bool stopSpawning = false;
	// Delai avant de debuter l'ensemble des générations
	public float spawnTime;
	// Delai entre chaque generation
	public float spawnDelay;

	/*
	public float minSpeed;
	public float maxSpeed;

	public bool leftDirection = false;
	public bool rightDirection = false;
	*/

	// pour generer un type bombe de manière aléartoire
	private int randomInt;

	// Use this for initialization
	void Start () {
		// InvokeRepeating est une methode d'Unity qui permet d'appeler indefiniment une fonction
		InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
	}

	// Genere les objets grace à la methode Instanciate
	public void SpawnObject() {
		// On choisi aléatoirement quel type de bombe generer
		randomInt = Random.Range(0, spawnees.Length);
		GameObject spawned = Instantiate(spawnees[randomInt], transform.position, Quaternion.identity) as GameObject;
		spawned.transform.parent = GameObject.Find ("EnemiesContainer").transform;

		/*
		float speed = Random.Range(minSpeed, maxSpeed);
		Vector3 direction = Vector3.zero;
		if( leftDirection ) {
			direction = Vector3.left;
		} else if( rightDirection ) {
			direction = Vector3.right;
		}


		spawned.GetComponent<Rigidbody> ().AddForce (direction * speed);
		*/

		// On arrete la generation si le booleen est activé
		if(stopSpawning) {
			CancelInvoke("SpawnObject");
		}
	}
}