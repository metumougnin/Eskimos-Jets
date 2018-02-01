using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerupsManager : MonoBehaviour {


	public int pillValue;


	public bool pill = false;

	public Player playerRef;

	public float jetpackEnergyValue = 25f;

	void Awake() {
		//playerRef = GameObject.FindObjectOfType<Player> ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		/*
		if (pill) {
			pill = false;
			Pill ();
			Debug.Log ("pill applied");
		}
		*/
	}
		

	public void Pill() {
		playerRef.AddHealth(pillValue);

		Debug.Log ("Player used a pill");
		//Debug.Log ("Player health:" + playerRef.health);
	}

	public void Shield() {
		playerRef.isShieldEnabled = true;
	}

	public void AddJetpackEnergyDefaultValue() {
		playerRef.AddJetpackEnergy (jetpackEnergyValue);
	}
}
