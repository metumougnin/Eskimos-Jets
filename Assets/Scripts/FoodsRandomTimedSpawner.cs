using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Permet de generer aléatoirement de la nourriture à une cadence regulière
public class FoodsRandomTimedSpawner : MonoBehaviour {

	// Liste des objets à generer
	public GameObject[] spawnees;
	// bolléen qui permet d'arreter la generation
	public bool stopSpawning = false;
	// Delai avant de debuter l'ensemble des générations
	public float spawnTime;
	// Delai entre chaque generation
	public float spawnDelay;
	// pour generer une bombe de manière aléartoire
	int randomInt;

	// Use this for initialization
	void Start () {
		// InvokeRepeating est une methode d'Unity qui permet d'appeler indefiniment une fonction
		InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
	}

	// Genere les objets grace à la methode Instanciate
	public void SpawnObject() {
		// On choisi aléatoirement quel type de bombe generer
		randomInt = Random.Range(0, spawnees.Length);
		Instantiate(spawnees[randomInt], transform.position, Quaternion.identity);

		// On arrete la generation si le booleen est activé
		if(stopSpawning) {
			CancelInvoke("SpawnObject");
		}
	}
}