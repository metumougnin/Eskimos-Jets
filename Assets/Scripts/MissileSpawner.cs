﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileSpawner : MonoBehaviour {

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

	// Use this for initialization
	void Start () {
		// InvokeRepeating est une methode d'Unity qui permet d'appeler indefiniment une fonction
		InvokeRepeating ( "SpawnObject", spawnTime, spawnDelay );
	}

	// Genere les objets grace à la methode Instanciate
	public void SpawnObject () {
		position = new Vector3 ( playerRef.transform.position.x, 30f, playerRef.transform.position.z );
		GameObject spawned = Instantiate( spawnee, position, Quaternion.identity ) as GameObject;
		spawned.transform.parent = GameObject.Find ("EnemiesContainer").transform;

		// On arrete la generation si le booleen est activé
		if ( stopSpawning ) {
			CancelInvoke ( "SpawnObject" );
		}
	}
}
