using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour {

	public bool isTaskOneCompleted = false;
	public bool isTaskTwoCompleted = false;
	public bool isTaskThreeCompleted = false;

	public GameObject taskOne;
	public GameObject taskTwo;
	public GameObject taskThree;
	public GameObject CongratulationMessage;

	public GameObject leftMarker;
	public GameObject rightMarker;
	public GameObject coinsRow;

	void Update() {
		if (isTaskOneCompleted && !isTaskTwoCompleted && !isTaskThreeCompleted) {
			taskOne.SetActive (false);
			taskTwo.SetActive (true);
			taskThree.SetActive (false);
			CongratulationMessage.SetActive (false);
			leftMarker.SetActive (false);
			rightMarker.SetActive (true);
			coinsRow.SetActive (false);
		} else if(isTaskOneCompleted && isTaskTwoCompleted && !isTaskThreeCompleted) {
			taskOne.SetActive (false);
			taskTwo.SetActive (false);
			taskThree.SetActive (true);
			CongratulationMessage.SetActive (false);
			leftMarker.SetActive (false);
			rightMarker.SetActive (false);
			coinsRow.SetActive (true);
		} else if(isTaskOneCompleted && isTaskTwoCompleted && isTaskThreeCompleted) {
			taskOne.SetActive (false);
			taskTwo.SetActive (false);
			taskThree.SetActive (false);
			CongratulationMessage.SetActive (true);
			coinsRow.SetActive (false);
		}
	}
}
