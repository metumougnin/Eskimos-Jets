using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTutorial : MonoBehaviour {

	public float rotationSpeed;

	// Update is called once per frame
	void FixedUpdate () {
		transform.Rotate (Vector3.up * Time.deltaTime * rotationSpeed);
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			Destroy (this.gameObject);
		}
	}
}
