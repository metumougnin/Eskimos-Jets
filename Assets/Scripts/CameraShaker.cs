using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Cette methode permet de faire remuer la camera principale lorsque le joueur est touché
public class CameraShaker : MonoBehaviour {

	// puissance de secouement
	public float power = 0.7f;
	// Duree  du secouement
	public float duration = 1.0f;
	// Revenir à la normale
	public float slowDownAmount = 1.0f;
	// booleen qui verifie si nous devons faire remuer la camera
	public bool shouldShake;

	// Reference sur le composant ransform de la camera principale
	private Transform cameraTransform;
	// Position de depart
	private Vector3 startPosition;
	// Duree
	private float initialDuration; 

	// Use this for initialization
	void Start () {
		cameraTransform = Camera.main.transform;
		startPosition = cameraTransform.localPosition;
		initialDuration = duration;
	}

	// Update is called once per frame 
	void Update () {
		if(shouldShake)
		{
			

			if(duration > 0)
			{
				//cameraTransform.localPosition = startPosition + Random.insideUnitSphere * power;
				cameraTransform.localPosition = startPosition + Random.insideUnitSphere * power;
				duration -= Time.deltaTime * slowDownAmount;
			}
			else
			{
				shouldShake = false;
				duration = initialDuration;
				cameraTransform.localPosition = startPosition;
			}
		}
	}
}