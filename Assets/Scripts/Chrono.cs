using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Classe mise en place pour la distribution des pieces de façon reguliere
// Cette classe est principalement utilisée par la classe Player
public class Chrono : MonoBehaviour {

	// Temps de generation maximal (en seconde)
	public float theTime;

	// Update is called once per frame
	void Update () {
		// Arreter la generation si le temps est ecoulé
		if (theTime > 0) {
			theTime -= Time.deltaTime;
		}
	}
			
}