using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// CLASSE OBSOLETE //

public class Etoile : MonoBehaviour {

	public CoinsByStarTimedSpawner left;
	public CoinsByStarTimedSpawner right;
	public CoinsByStarTimedSpawner topLeft;
	public CoinsByStarTimedSpawner topRight;

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Player") {
			left.stopSpawning = false; left.Start ();
			right.stopSpawning = false; right.Start ();
			topLeft.stopSpawning = false; topLeft.Start ();
			topRight.stopSpawning = false; topRight.Start ();
			
			Destroy (this.gameObject);
		}
	}
}
