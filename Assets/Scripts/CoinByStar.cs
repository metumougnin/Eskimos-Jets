using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinByStar : Coin {

	//AudioClip coinSound;

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Player") {
			//AudioSource.PlayClipAtPoint (coinClip, transform.position);
			//totalCoins++;
			Destroy (this.gameObject);
		}
	}
}
