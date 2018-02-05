using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public static bool GameIsPaused = false;
	public GameObject pauseMenu;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (GameIsPaused) {
				ResumeGame ();
			} else {
				PauseGame ();
			}
		}
	}

	public void ResumeGame() {
		pauseMenu.SetActive (false);
		Time.timeScale = 1f;
		GameIsPaused = false;
	}

	void PauseGame() {
		pauseMenu.SetActive (true);
		Time.timeScale = 0f;
		GameIsPaused = true;
	}

	public void BackToMainMenu( string mainMenuName ) {
		Time.timeScale = 1f;
		SceneManager.LoadScene (mainMenuName);
	}

	public void ExitGame() {
		pauseMenu.SetActive (false);
		Time.timeScale = 1f;

		if (Application.platform == RuntimePlatform.Android) {
			AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
			activity.Call<bool>("moveTaskToBack", true);
		} else {
			Application.Quit();
		}
	}
}
