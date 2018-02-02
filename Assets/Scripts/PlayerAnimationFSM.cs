using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationFSM : MonoBehaviour {

	public Jetpack jetpack;

	private Player player;

	// Reference sur le joueur
	private PlayerMovements playerMovementsRef;

	// Reference sur le composant Animator
	private Animator anim;

	// Affectation des references
	void Awake(){
		playerMovementsRef = PlayerMovements.FindObjectOfType<PlayerMovements> ();
		anim = GetComponent<Animator> ();

		player = GameObject.FindObjectOfType<Player> ();
	}

	// Use this for initialization
	void Start () {
		jetpack.transform.position = new Vector3 (player.transform.position.x + 1f, player.transform.position.y, player.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		//anim.SetBool ("isPlayerRunning", playerMovementsRef.isRunning);

		if (player.isPoisoned)
			anim.SetBool( "isPoisoned", true );
		else
			anim.SetBool( "isPoisoned", false );

		if (playerMovementsRef.horizontalAxis < 0)
			jetpack.transform.position = new Vector3 (player.transform.position.x + 1f, player.transform.position.y, player.transform.position.z);
		else if (playerMovementsRef.horizontalAxis > 0) 
			jetpack.transform.position = new Vector3 (player.transform.position.x - 0.5f, player.transform.position.y, player.transform.position.z);
		
		if (playerMovementsRef.horizontalAxis < 0 && player.GetComponent<Rigidbody>().velocity.y == 0f) {
			anim.SetBool ("isRunningLeft", true);
			anim.SetBool ("isRunningRight", false);
			jetpack.transform.position = new Vector3 (player.transform.position.x + 1f, player.transform.position.y, player.transform.position.z);
		} else if (playerMovementsRef.horizontalAxis > 0 && player.GetComponent<Rigidbody>().velocity.y == 0f) {
			anim.SetBool ("isRunningLeft", false);
			anim.SetBool ("isRunningRight", true);
		} else {
				anim.SetBool ("isRunningLeft", false);
				anim.SetBool ("isRunningRight", false);
		}
	}
}
