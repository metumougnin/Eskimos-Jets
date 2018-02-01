using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Permet de generer des pieces regulièrement
public class CoinsByStarTimedSpawner : MonoBehaviour {

	// Liste des objets à generer
	public GameObject spawnee;
	// bolléen qui permet d'arreter la generation
	public bool stopSpawning = true;
	// Delai avant de debuter l'ensemble des générations
	public float spawnTime;
	// Delai entre chaque generation
	public float spawnDelay;
	// Temps de generation maximal (en seconde)
	public float lifeTime = 5f;

	// Update is called once per frame
	void Update () {
		// Arreter la generation si le temps est ecoulé
		if (lifeTime > 0 && !stopSpawning) {
			lifeTime -= Time.deltaTime;
			if (lifeTime <= 0) {
				stopSpawning = true;
				lifeTime = 5f;

			}
		}
	}

	// Use this for initialization
	public void Start () {
		// InvokeRepeating est une methode d'Unity qui permet d'appeler en boucle de maniere infini une fonction
		if(!stopSpawning)
			InvokeRepeating("SpawnCoins", spawnTime, spawnDelay);
	}

	// Genere les objets grace à la methode Instanciate
	public void SpawnCoins() {
		Instantiate (spawnee,  transform.position, Quaternion.identity);

		// On arrete la generation si le booleen est activé
		if(stopSpawning) {
			CancelInvoke("SpawnCoins");
		}
	}
}