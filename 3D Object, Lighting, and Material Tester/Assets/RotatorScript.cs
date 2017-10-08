using UnityEngine;
using System.Collections;

public class RotatorScript : MonoBehaviour {
	
	public GameObject Rotator;

	public bool dir;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Rotator.transform.Rotate (Vector3.up * Time.deltaTime * 60);
		if (Rotator.transform.position.y < -10) {
			dir = true;
		} 

		if (Rotator.transform.position.y > 10){
			dir = false;
		}
		
		if (dir) {
			//Rotator.transform.position = Vector3.up * Time.deltaTime * 10;
		} else {
			//Rotator.transform.position = Vector3.down * Time.deltaTime * 10;
		}

	}
}
