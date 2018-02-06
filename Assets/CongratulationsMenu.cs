using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Congratulations menu.
/// Base class for the Congratulations Scene
/// </summary>
public class CongratulationsMenu : MonoBehaviour {

	/// <summary>
	/// Reference to the main DataManager
	/// </summary>
	private DataManager dataManager;

	/// <summary>
	/// Reference to the main LevelManager.
	/// </summary>
	public LevelManager levelManager;


	void Awake() {
		dataManager = DataManager.FindObjectOfType<DataManager> ();
	}

	/// <summary>
	/// Continues the button: Allows the player to continue the next scene
	/// </summary>
	public void ContinueButton() {
		if( dataManager.totalCrates > 0) {
			levelManager.LoadScene ("BCrateFromGameScene");
		}
	}
}
