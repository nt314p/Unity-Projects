using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;

	public Vector3 target;


	void Update() {
		if (!Player.dead && !Player.powerLoss) {
			target = player.transform.position + new Vector3 (0, 21, -50);
			transform.position = target;
		}
	}
}
