using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour {

	private DataManager dataManager;

	void Awake() {
		dataManager = DataManager.FindObjectOfType<DataManager> ();
	}

	void OnCollisionEnter ( Collision other ) {
		if( other.gameObject.tag == "Player" ) {
			dataManager.totalCrates++;
			Destroy (this.gameObject);
		}
	}
}
