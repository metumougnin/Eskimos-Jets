using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text scoreText;
	public int scorePoints = 5;
	private DataManager dataManager;

	//private int score;


	void Awake() {
		dataManager = DataManager.FindObjectOfType<DataManager> ();
	}


	public void SettoZero() {
		//score = 0;
		dataManager.score = 0;
	}
		
	
	// Update is called once per frame
	void Update () {
		//score += 5;
		//DataManager.instance.score += 5;
		scoreText.text = dataManager.score.ToString ();
	}

	public void AddScorePoints() {
		dataManager.score += scorePoints;
	}

	public void AddScorePointsWithValue(int value) {
		dataManager.score += value;
	}
}
