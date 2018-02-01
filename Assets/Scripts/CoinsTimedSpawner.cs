using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// CLASSE OBSOLETE //

// Permet de generer des pieces regulièrement
public class CoinsTimedSpawner : MonoBehaviour {

	// Liste des objets à generer
	public GameObject spawnee;
	// bolléen qui permet d'arreter la generation
	public bool stopSpawning = false;
	// Delai avant de debuter l'ensemble des générations
	public float spawnTime;
	// Delai entre chaque generation
	public float spawnDelay;

	// Stocke la position de la prochaine piece à generer
	Vector3 positionNextCoin;

	// Use this for initialization
	void Start () {
		// InvokeRepeating est une methode d'Unity qui permet d'appeler
		// indefiniment une fonction
		InvokeRepeating("SpawnCoins", spawnTime, spawnDelay);
	}

	// Genere les objets grace à la methode Instanciate
	public void SpawnCoins() {
		float x = Random.Range (2, 25);
		float y = Random.Range (3, 15);
		//positionNextCoin = transform.position;
		positionNextCoin = new Vector3(x, y, 6f);
		for (int count = 0; count < 10; count++) {
			positionNextCoin.x += 2;
			Instantiate (spawnee,  positionNextCoin, Quaternion.identity);
		}

		// On arrete la generation si le booleen est activé
		if(stopSpawning) {
			CancelInvoke("SpawnCoins");
		}
	}
}