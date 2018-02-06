using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticField : MonoBehaviour {

	private Player playerRef;
	private bool hasCoinMoved = false;
	public float forcePower = 10f;

	void Awake() {
		playerRef = Player.FindObjectOfType<Player> ();
	}
	
	// Update is called once per frame
	void Update () {
		//GetComponent<Rigidbody> ().AddForce( ( playerRef.transform.position - transform.position ) * forcePower * Time.smoothDeltaTime);

		if (playerRef.isMagnetEnabled) {
			transform.position = Vector3.MoveTowards (transform.position, playerRef.transform.position, forcePower * Time.deltaTime);
			hasCoinMoved = true;
		} else {
			if (hasCoinMoved) {
				transform.position = Vector3.MoveTowards (transform.position, playerRef.transform.position, forcePower * Time.deltaTime);
			}
		}
	}
}
