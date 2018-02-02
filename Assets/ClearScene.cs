using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clear scene: Clean the scene from all enemies
/// </summary>
public class ClearScene : MonoBehaviour {

	private GameObject enemiesContainer;

	void Awake() {
		enemiesContainer = GameObject.Find( "EnemiesContainer" );
	}

	void OnTriggerEnter( Collider other ) {
		if (other.gameObject.tag == "Player") {	
			foreach (Transform bomb in enemiesContainer.transform) {
				Destroy (bomb.gameObject);
			}

			Destroy (this.gameObject);
		}
	}
}
