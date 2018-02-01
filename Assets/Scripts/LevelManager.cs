using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Gere le chargement des levels et menus du jeu
public class LevelManager : MonoBehaviour {

	public void LoadLevel(int level){
	}

	public void LoadScene(string scene){
		SceneManager.LoadScene(scene);
	}
}
