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

	void OnCollisionEnter(Collision other) {
		if(other.gameObject.tag == "Player") {
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
		Destruction ();
	}

	// Methode de destruction
	void Destruction() {
		Destroy(this.gameObject);
	}
}
