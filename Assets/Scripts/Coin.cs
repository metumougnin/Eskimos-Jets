using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Based Class for coins
public class Coin : MonoBehaviour {

	public float rotationSpeed;

	public  static int totalCoins;

	//[HideInInspector]
	protected GameObject PickedUpSound;

	public AudioClip coinClip;

	// Use this for initialization
	void Awake () {
		//totalCoins = 0;
	}

	void Start(){
		PickedUpSound = GameObject.Find ("Coin PickUp Clip");
	}

	void Update(){
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Rotate (Vector3.up * Time.deltaTime * rotationSpeed);
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			//PickedUpSound.GetComponent<AudioSource> ().Play ();
			AudioSource.PlayClipAtPoint(coinClip, transform.position);
			totalCoins++;
			Destroy (this.gameObject);
		}
	}
}
