using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour {

	/*
	public CoinsByStarTimedSpawner left;
	public CoinsByStarTimedSpawner right;
	public CoinsByStarTimedSpawner topLeft;
	public CoinsByStarTimedSpawner topRight;
	*/

	// Si le joueur a decroché l'etoile
	private bool isStarActive = false;
	// timer si le joeur a touché l'etoile
	private float timer = 10f;
	// timer si le joueur n'a pas touché l'étoile
	private float timer2 = 5f;

	void Update() {
		if (isStarActive) {
			if (timer > 0f) {
				foreach (Transform coin in GameObject.Find( "CoinsRowContainer" ).transform) {
					Destroy (coin.gameObject);
				}

				timer -= Time.deltaTime;
			} else {
				isStarActive = false;
				timer = 10f;
				Destruction ();
			}
		} else {
			if (timer2 > 0) {
				timer2 -= Time.deltaTime;
			} else {
				Destruction ();
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Player") {
			isStarActive = true;
			CoinsByStarTimedSpawner[] coinsByStars = CoinsByStarTimedSpawner.FindObjectsOfType<CoinsByStarTimedSpawner> ();
			foreach (CoinsByStarTimedSpawner spawner in coinsByStars) {
				spawner.stopSpawning = false;
				spawner.Start (); 
			}
		}
		/*
		left.stopSpawning = false; left.Start (); 
		right.stopSpawning = false; right.Start (); 
		topLeft.stopSpawning = false; topLeft.Start (); 
		topRight.stopSpawning = false; topRight.Start (); 
		*/

		//Destruction ();
		this.gameObject.GetComponent<MeshRenderer>().enabled = false;
	}

	// Methode de destruction
	void Destruction() {
		Destroy(this.gameObject);
	}
}
