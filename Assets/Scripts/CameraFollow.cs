using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public GameObject playerRef;
	public float yPos;
	public float zPos;
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (playerRef.transform.position.x, yPos, zPos);
	}
}
