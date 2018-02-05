using UnityEngine;

/// <summary>Manages data for persistance between levels.</summary>
public class DataManager : MonoBehaviour 
{
	/// <summary>Static reference to the instance of our DataManager</summary>
	public static DataManager instance;

	/// <summary>The player's current score.</summary>
	public int score;
	/// <summary>The player's remaining health.</summary>
	public int health;
	/// <summary>The player's remaining lives.</summary>
	//public int lives;
	/// <summary>The player's actual coins.</summary>
	public int coins;
	/// <summary>Determine whether or not the players broke the highscore.</summary>
	public bool newhighScoreFlag = false;
	/// <summary>Determine whether or not the players broke the highscore.</summary>
	public int totalCrates;

	/// <summary>Awake is called when the script instance is being loaded.</summary>
	void Awake()
	{
		// If the instance reference has not been set, yet, 
		if (instance == null)
		{
			// Set this instance as the instance reference.
			instance = this;
		}
		else if(instance != this)
		{
			// If the instance reference has already been set, and this is not the
			// the instance reference, destroy this game object.
			Destroy(gameObject);
		}

		// Do not destroy this object, when we load a new scene.
		DontDestroyOnLoad(gameObject);
	}
}