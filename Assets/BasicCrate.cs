using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicCrate : MonoBehaviour {

	public Text prizeText;
	private DataManager dataManager;
	public LevelManager levelManager;

	void Awake() {
		dataManager = DataManager.FindObjectOfType<DataManager> ();
	}

	public void OpenBasicCrate() {

		int coinsPrize = Random.Range (100, 1000);
		prizeText.text = coinsPrize + " coins";
		dataManager.totalCrates--;

		//
		int totalCoins = PlayerPrefs.GetInt ( "coins", 0 );
		totalCoins += coinsPrize;
		PlayerPrefs.SetInt ( "coins", totalCoins );
	}

	public void ContinueFromCrateGame() {
		if (dataManager.totalCrates == 0) {
			levelManager.LoadScene ("ScoreSummaryScene");
		} else {
			levelManager.LoadScene ("BCrateFromGameScene");
		}
	}
}
