using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Cette Classe gere l'initialisation des bombes
public class Bomb : MonoBehaviour {

	// Dommages infligés par chaque type de bombe
	public int bigBombDamages;
	public int midSizeBombDamages;
	public int smallBombDamages;
	public float timeBeforeLerp = 3f;
	public GameObject wallHit;

	// Reference sur le sous element bombdestruyer
	private BombDestroyer destroyerRef;
	// Reference sur le sous element colorlerper
	private ColorLerper colorLerperRef;

	// indique si la bombe a explosé ou non
	private bool hasExploded = false;

	// Affectaton des references
	void Awake(){
		destroyerRef = GetComponent<BombDestroyer> ();
		colorLerperRef = GetComponent<ColorLerper> ();
	}

	void OnCollisionEnter(Collision other) {
		if(other.gameObject.tag == "Lateral Walls") {
			//Instantiate (wallHit, transform.position, Quaternion.identity);
			//CFX_SpawnSystem.GetNextObject(wallHit);
			GameObject instance = CFX_SpawnSystem.GetNextObject(wallHit);
			instance.transform.position = transform.position;
		}
	}
		
	
	// Update is called once per frame
	void Update () {
		// S'il reste moins de 3 seconde avant que la bombe ne disparaisse, on change la couleur. Elle passe  du noir au rouge.
		if((destroyerRef.lifeTime < timeBeforeLerp) && !hasExploded){
			colorLerperRef.ActivateColorLerp ();
		}
	}
		
}
