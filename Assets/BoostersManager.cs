using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostersManager : MonoBehaviour {

	public Player playerRef;

	public void UseHeartBooster() {
		playerRef.AddHealth (playerRef.maxHealth);
	}

	public void UseEnergyBooster() {
		playerRef.AddJetpackEnergy (playerRef.jetpackEnergyMax);
	}

	public void UsePotionBooster() {
		playerRef.isPoisoned = false;
	}

	public void UseMagnetBooster() {
		playerRef.isMagnetEnabled = true;
	}
}
