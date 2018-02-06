using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsRowTutorial : MonoBehaviour {

	public TutorialController tutorialController;
	private int count;

	void Update() {

		count = 0;
		foreach(Transform child in transform) {
			count++;
		}

		if (count == 0) {
			tutorialController.isTaskOneCompleted = true;
			tutorialController.isTaskTwoCompleted = true;
			tutorialController.isTaskThreeCompleted = true;
		}
	}
}
