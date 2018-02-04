using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour {

	public AudioMixer audioMixer;
	public Text graphicsDropdownLabel;
	public Dropdown graphicsSettings;

	public Text highscoreTextValue;
	public Text totalCoinsValue;

	public DeterminePlayerCharacter playerRef;

	private string currentCharacter;
	public string defaultCharacterName = "P1";


	void Start() {
		//string currentCharacter = PlayerPrefs.GetString ("playerCharacter", "P1");
	}

	void Update() {

		highscoreTextValue.text =  PlayerPrefs.GetInt( "highScore", 0 ).ToString();
		totalCoinsValue.text =  PlayerPrefs.GetInt( "coins", 0 ).ToString();
		

		//
		switch( QualitySettings.GetQualityLevel() ) {
		case 0:
			graphicsDropdownLabel.text = "Very Low";
			break;
		case 1:
			graphicsDropdownLabel.text = "Low";
			break;
		case 2:
			graphicsDropdownLabel.text = "Medium";
			break;
		case 3:
			graphicsDropdownLabel.text = "High";
			break;
		case 4:
			graphicsDropdownLabel.text = "Very High";
			break;
		case 5:
			graphicsDropdownLabel.text = "Ultra";
			break;
		default:
			break;
		}

		setGraphicsQuality( QualitySettings.GetQualityLevel() );
		graphicsSettings.value = QualitySettings.GetQualityLevel();
	}


	public void SetVolume( float volume ) {
		//Debug.Log( volume );
		audioMixer.SetFloat( "volume", volume );
	}

	public void setGraphicsQuality( int qualityLevel ) {

		QualitySettings.SetQualityLevel( qualityLevel );
	}

	// fonction temporaire
	public void ResetHighscore() {
		PlayerPrefs.SetInt( "highScore", 0 );
	}

	public void CharacterSelection ( string name ) {
		currentCharacter = PlayerPrefs.GetString( "playerCharacter", defaultCharacterName );
		//GameObject.Find( currentCharacter ).SetActive( true );

		// desactiver l'ancier personnage
		foreach( Transform child in playerRef.transform ) {
			if( child.gameObject.name == currentCharacter ) {
				child.gameObject.SetActive( false );
			}
		}


		// activer le nouveau personnage dans les prefs
		PlayerPrefs.SetString( "playerCharacter", name );
	}
}
