using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Scene cleaner spawner: Genere l'objet sur une position x aléatoire
/// </summary>
public class SceneCleanerSpawner : MonoBehaviour {

	// objet à generer
	public GameObject spawnee;
	// booleen qui permet d'arreter la generation
	public bool stopSpawning = false;
	// Delai avant de debuter l'ensemble des generations
	public float spawnTime;
	// Delai entre chaque generation
	public float spawnDelay;

	public Player playerRef;
	Vector3 position;

	// Use this for initialization
	void Start () {
		// InvokeRepeating est une methode d'Unity qui permet d'appeler indefiniment une fonction
		InvokeRepeating ( "SpawnObject", spawnTime, spawnDelay );
	}

	// Genere les objets grace à la methode Instanciate
	public void SpawnObject () {
		float xPos = playerRef.transform.position.x;
		while( ( xPos > playerRef.transform.position.x - 3f ) && ( xPos < playerRef.transform.position.x + 3f ) ) {
			xPos =  Random.Range (4f, 38f);
		}

		position = new Vector3 ( xPos, 1.3f, playerRef.transform.position.z );
		Instantiate( spawnee, position, Quaternion.identity );

		// On arrete la generation si le booleen est activé
		if ( stopSpawning ) {
			CancelInvoke ( "SpawnObject" );
		}
	}
}
