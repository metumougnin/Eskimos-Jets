using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightMarkerTutorial : MonoBehaviour {

	public TutorialController tutorialController;

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Player") {
			tutorialController.isTaskOneCompleted = true;
			tutorialController.isTaskTwoCompleted = true;
			tutorialController.isTaskThreeCompleted = false;
		}
	}
}
