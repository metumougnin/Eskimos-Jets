using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Player Class for the tutorial Scene.
/// </summary>
public class PlayerTutorial : MonoBehaviour {


	// Ref source audio, collecte de piece;
	//public GameObject PickedUpSound;


	 
	// Santé du joueur
	public int health = 100;

	//
	//public ScoreManager scoreManager;
	//private DataManager dataManager;

	/*
	public GameObject highScoreHUD;

	//
	public Text floatingText;
	public Text floatingTextPosRef;
	public GameObject hud;
	*/

	//
	public float jetpackEnergyMax;
	public float jetpackEnergyReduceValue;
	//public Image jetpackEnergyBar;
	public bool isJetPackEnabled = true;
	private float jetpackEnergy;
	//

	public bool isPoisoned = false;

	// Camera Principale
	public Camera theMainCamera;


	void Start() {
		jetpackEnergy = jetpackEnergyMax;
	}


	/*
	public void PrintFloatingText(string theText) {
		floatingText.text = theText;
		Text instance = Instantiate (floatingText, floatingTextPosRef.transform.position, Quaternion.identity) as Text;
		//Text instance = Instantiate (floatingText, new Vector3 (transform.position.x + 10f, transform.position.y + 3f, transform.position.z), Quaternion.identity) as Text;
		instance.transform.SetParent( hud.transform );
	}
	*/

	/*
	public void AddJetpackEnergy(float value) {
		jetpackEnergy += value;
		if (jetpackEnergy > jetpackEnergyMax)
			jetpackEnergy = jetpackEnergyMax;

		string str = "Jetpack + " + value.ToString();
		PrintFloatingText (str);
	}
	*/


	public void JetpackEnergyReduce(){
		jetpackEnergy -= jetpackEnergyReduceValue;
		if (jetpackEnergy <= 0f) {
			jetpackEnergy = 0f;
			//isJetPackEnabled = false;
		}
	}



	void FixedUpdate() {
		// Remplissage regulier de l'energie du JetPack;
		if(jetpackEnergy < jetpackEnergyMax) {
			jetpackEnergy += 0.01f;
		}

		//scoreManager.AddScorePoints ();
	}

	// Update is called once per frame
	void Update () {
		//jetpackEnergyBar.fillAmount = jetpackEnergy / jetpackEnergyMax;

		if (jetpackEnergy <= 0.1f) {
			isJetPackEnabled = false;
		} else if (jetpackEnergy >= 5f) {
			isJetPackEnabled = true;
		}


		/*
		// Si le joueur gagne, on affiche la scene de victoire
		if (levelScore >= levelGoal) {
			levelManager.LoadScene ("Win_Scene");
		}
		*/


	}

	/*
	// La fonction qui ajoute des points au joueuers lorsqu'il ramasse de la nourriture
	void addPoints (int points){
		levelScore += points;
	}
	*/

}
