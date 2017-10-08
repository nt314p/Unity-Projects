using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpin : MonoBehaviour {

	public float dir = -0.01f;
	public GameObject highscoreCanvas;
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.up, 10 * Time.deltaTime);

		// moving canvas up and down
		highscoreCanvas.transform.position += Vector3.up*dir*Time.deltaTime;

		// moving the hovercraft up and down
		transform.position += Vector3.up*dir*Time.deltaTime;

		// changing direction
		if (transform.position.y > 8	 || transform.position.y < 6) {
			dir *= -1;
		}

	}
}
