using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Permet de changer la couleur d'un objet
public class ColorLerper : MonoBehaviour {

	// Vitesse de transition
	public float speed = 1.0f;
	// Couleur de base
	public Color startColor;
	// Coleur finale
	public Color endColor;
	// booleen qui indique si la transition doit etre repetee ou pas
	public bool repeatable = false;

	// stocke le temps de demarrage du script
	private float startTime;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}


	public void ActivateColorLerp () {
		if (!repeatable)
		{
			float t = (Time.time - startTime) * speed;
			GetComponent<Renderer>().material.color = Color.Lerp(startColor, endColor, t);
		}
		else
		{
			float t = (Mathf.Sin(Time.time - startTime) * speed);
			GetComponent<Renderer>().material.color = Color.Lerp(startColor, endColor, t);
		}
	}
}