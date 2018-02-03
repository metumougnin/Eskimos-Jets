using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///<summary> Classe de base du joueur </summary>
public class Player : MonoBehaviour {

	// Santé maximum du joeur
	public int maxHealth;
	// Texte qui indique la valeur numerique de la vie en pleine partie
		//public Text healthTextInt;
	// Bar de santé du joueur
	public Image healthBar;
	// Indique si le joeur est mort
	public bool isDead;
	// Reference sur le level Manager
	public LevelManager levelManager;
	// Reference sur un objet bombe
	public Bomb bombRef;
	// Texte qui affiche le nombre de pieces
	public Text coinsNumberText;

	// Ref source audio, collecte de piece;
	public GameObject PickedUpSound;

	/*
	// References spawners de pieces
	public CoinsByStarTimedSpawner left;
	public CoinsByStarTimedSpawner right;
	public CoinsByStarTimedSpawner topLeft;
	public CoinsByStarTimedSpawner topRight;
	*/

	// Variables temporaires necessaires pour le bon fonctionnement du chrono
	float tmpChronoTime;
	float tmpLifeimeSpwanCoins;

	// Le Chrono pour distribuer des pieces au joeur
	Chrono chronoPieces;


	public int levelGoal = 120;
	public int levelScore = 0;
	public Text levelGoalNumberText;
	public Text levelScoreNumberText;
	public Food foodRef;


	// Santé du joueur
	public int health = 100;

	//
	public ScoreManager scoreManager;

	//
	public Text floatingText;
	public Text floatingTextPosRef;
	public GameObject hud;

	//
	public float jetpackEnergyMax;
	public float jetpackEnergyReduceValue;
	public Image jetpackEnergyBar;
	public bool isJetPackEnabled = true;
	private float jetpackEnergy;
	//
	public bool isShieldEnabled = false;
	public float shieldLifeTime = 5f;
	private bool shieldCounterFlag = false;
	private float shieldCountdown;
	public GameObject shield;

	//
	public bool isPoisoned = false;
	public float poisonDuration = 3f;
	public float poisonDurationCopy;
	public GameObject poisonIndicator;

	// Couches
	private int bombsLayer = 10;
	private int foodsLayer = 12;

	// Camera Principale
	public Camera theMainCamera;



	[Header("Flash Screens")]
	// Variables necessaires pour les flashscreen
	bool isPlayerDamaged = false;
	float countInvoke = 0;
	public Image damageImage;
	public Color damageFlashColor;
	public float damageFlahSpeed;


	public void PrintFloatingText(string theText) {
		floatingText.text = theText;
		Text instance = Instantiate (floatingText, floatingTextPosRef.transform.position, Quaternion.identity) as Text;
		//Text instance = Instantiate (floatingText, new Vector3 (transform.position.x + 10f, transform.position.y + 3f, transform.position.z), Quaternion.identity) as Text;
		instance.transform.SetParent( hud.transform );
	}

	public void AddJetpackEnergy(float value) {
		jetpackEnergy += value;
		string str = "Jetpack + " + value.ToString();
		PrintFloatingText (str);
	}


	public void JetpackEnergyReduce(){
		jetpackEnergy -= jetpackEnergyReduceValue;
		if (jetpackEnergy <= 0f) {
			jetpackEnergy = 0f;
			//isJetPackEnabled = false;
		}
	}


	public void AddHealth(int value) {
		health += value;
		if (health > maxHealth) {
			health = maxHealth;
		}

		string str = "Health + " + value.ToString();
		PrintFloatingText (str);
	}

	void Awake(){
		chronoPieces = GetComponent<Chrono>();
	}

	// Use this for initialization
	void Start () {
		health = maxHealth;
		//healthTextInt.text = health.ToString ();
		isDead = false;
		Coin.totalCoins = 0;

		scoreManager.SettoZero ();


		jetpackEnergy = jetpackEnergyMax;
		isJetPackEnabled = true;

		poisonDurationCopy = poisonDuration;
	}

	void FixedUpdate() {
		// Remplissage regulier de l'energie du JetPack;
		if(jetpackEnergy < jetpackEnergyMax) {
			jetpackEnergy += 0.01f;
		}

		scoreManager.AddScorePoints ();
	}
	
	// Update is called once per frame
	void Update () {
		jetpackEnergyBar.fillAmount = jetpackEnergy / jetpackEnergyMax;

		if (jetpackEnergy <= 0.1f) {
			isJetPackEnabled = false;
		} else if (jetpackEnergy >= 5f) {
			isJetPackEnabled = true;
		}

		if (isPoisoned && (poisonDurationCopy >= 0f)) {
			poisonDurationCopy -= Time.deltaTime;
			poisonIndicator.SetActive( true );
		} else {
			isPoisoned = false;
			poisonDurationCopy = poisonDuration;
			poisonIndicator.SetActive( false );
		}


		// Afficher le nombre de pieces recoltees par le joueur
		coinsNumberText.text = Coin.totalCoins.ToString ();

		// Afficher la valeur numerique de la santé du joueur
			//healthTextInt.text = health.ToString ();
		// Mise à jour barre de santé du joueur
		healthBar.fillAmount = (float)health / (float)maxHealth;

		// Mise a jour textes du HUD
		levelGoalNumberText.text = levelGoal.ToString();
		levelScoreNumberText.text = levelScore.ToString ();


		// Si le joeur est mort, on arrete la partie
		if (isDead) {
			levelManager.LoadScene ("Score");
		}

		// Si le joueur gagne, on affiche la scene de victoire
		if (levelScore >= levelGoal) {
			levelManager.LoadScene ("Win_Scene");
		}

		if(isShieldEnabled) {
			if (!shieldCounterFlag) {
				shieldCountdown = shieldLifeTime;
				shield.SetActive (true);
				shieldCounterFlag = true;
			}

			if (shieldCountdown > 0) {
				shieldCountdown -= Time.deltaTime;
			} else {
				shield.SetActive (false);
				shieldCounterFlag = false;
				isShieldEnabled = false;
			}
		}


		if (health <= 20) {
			if (countInvoke == 0) {
				InvokeRepeating ("FlashAlert", 0.1f, 0.5f);
				countInvoke++;
			} 
		} else {
			countInvoke = 0;
			CancelInvoke("FlashAlert");
		}

		damageFlash ();	
	}

	// Si le joueur est touché par une bombe, on lui inflige les degats correspondants
	// Si le joueur entre en contact avec de la nourriture, on lui atribue des points
	void OnCollisionEnter(Collision other){
		if (other.gameObject.layer == bombsLayer) {
			if (other.gameObject.tag == "Small Bombs")
				TakeDamages (bombRef.smallBombDamages);
			else if (other.gameObject.tag == "Mid Size Bombs")
				TakeDamages (bombRef.midSizeBombDamages);
			else if (other.gameObject.tag == "Big Bombs")
				TakeDamages (bombRef.bigBombDamages);

			// On remue la camera si le joueur est touché en activant un booleen dans la
			// classe CameraShaker
			GetComponent<CameraShaker> ().shouldShake = true;

			// On detruit la bombe (La bombe explose)
			Destroy (other.gameObject);

		} else if (other.gameObject.layer == foodsLayer) {
			if (other.gameObject.tag == "Banana") {
				addPoints (foodRef.bananaPoints);
			}

			// Detruire l'objet
			Destroy (other.gameObject);
		} 
	}


	// La fonction qui ajoute des points au joueuers lorsqu'il ramasse de la nourriture
	void addPoints (int points){
		levelScore += points;
	}

	// Inflige les degats au joueur et met à jour sa barre de santé
	// On signe egalement grace à un booleen lorque l'enemi n'a plus de vie, afin que
	// la partie s'arrête
	public void TakeDamages(int damages){
		isPlayerDamaged = true;

		if (!isShieldEnabled) {
			health -= damages;
		} else {
			string str = "Score + " + damages.ToString ();
			scoreManager.AddScorePointsWithValue (damages);
			PrintFloatingText (str);
		}


		if (health <= 0)
			isDead = true;
	}

	// Permet d'afficher un flash screen rouge rapide lorsque le joueur est touché par
	// un element qui lui retire des points de santé
	void damageFlash(){
		// Si le joueur est touché, affihcer l'ecran rouge
		// Sinon, quitter l'ecran rouge pour revenir à la normale.
		if (isPlayerDamaged) {
			damageImage.color = damageFlashColor;
		} else {
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, damageFlahSpeed * Time.deltaTime);
		}

		// On remet le booléen à false, afin que l'ecran ne reste pas rouge indefiniment
		isPlayerDamaged = false;
	}

	// Fonction permettant de faire clignoter l'ecran avec un flash screen rouge lorsque la barre
	// de vie du joueur est très faible. 20% par exemple.
	void FlashAlert(){
		damageImage.color = Color.Lerp (damageFlashColor, Color.clear, damageFlahSpeed * Time.deltaTime);
	}
}
