using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingText : MonoBehaviour {


	private Color tmpColor;

	// Use this for initialization
	void Start () {
		tmpColor = GetComponent<Text> ().color;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		tmpColor.a -= 0.01f;
		GetComponent<Text> ().color = tmpColor;
		transform.position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
	}
}
