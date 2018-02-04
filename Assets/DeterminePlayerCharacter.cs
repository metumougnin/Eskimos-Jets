using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeterminePlayerCharacter : MonoBehaviour {

	public string defaultCharacterName = "P1";
	string currentCharacter;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		currentCharacter = PlayerPrefs.GetString( "playerCharacter", defaultCharacterName );
		//GameObject.Find( currentCharacter ).SetActive( true );

		foreach( Transform child in transform ) {
			if( child.gameObject.name == currentCharacter ) {
				child.gameObject.SetActive( true );
			}
		}
	}
}
