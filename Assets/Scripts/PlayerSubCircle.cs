using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player sub circle.
/// Base Class for the subcircle which follow the player
/// </summary>
public class PlayerSubCircle : MonoBehaviour {

	public Player playerRef;

	void FixedUpdate() {
		transform.position = new Vector3 (playerRef.transform.position.x, transform.position.y, transform.position.z);
	}
}
