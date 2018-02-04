using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text scoreTextValue;
	public Text coinsTextValue;

	public int scorePoints = 5;
	private DataManager dataManager;

	private int highScore;


	//private int score;

	void Start() {
		highScore = PlayerPrefs.GetInt( "highScore", 0 );
	}


	void Awake() {
		dataManager = DataManager.FindObjectOfType<DataManager> ();
	}


	public void SettoZero() {
		//score = 0;
		dataManager.score = 0;
		dataManager.coins = 0;
		dataManager.newhighScoreFlag = false;
	}
		
	
	// Update is called once per frame
	void Update () {
		//score += 5;
		//DataManager.instance.score += 5;
		scoreTextValue.text = dataManager.score.ToString();
		coinsTextValue.text = dataManager.coins.ToString();

		if( dataManager.score > highScore ) {
			//TODO: afficher new highscore dans le HUD
			// set the new highscore flag 

			dataManager.newhighScoreFlag = true;
		}
			
	}

	public void AddScorePoints() {
		dataManager.score += scorePoints;
	}

	public void AddScorePointsWithValue(int value) {
		dataManager.score += value;
	}
}
