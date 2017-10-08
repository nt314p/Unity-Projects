using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CardHandler : MonoBehaviour {

	public GameObject two_of_clubs;
	public int two_of_clubsYtar = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (two_of_clubs.transform.rotation.y < two_of_clubsYtar) {
			Quaternion originalRot = transform.rotation;    
			two_of_clubs.transform.rotation = originalRot * Quaternion.AngleAxis(-1, Vector3.up);
		}
		if (two_of_clubs.transform.rotation.y > two_of_clubsYtar) {
			Quaternion originalRot = transform.rotation;    
			two_of_clubs.transform.rotation = originalRot * Quaternion.AngleAxis(1, Vector3.up);
		}
	}

	public void two_of_clubsButton () {
		
		two_of_clubsYtar = ((two_of_clubsYtar/-180) + 1) * 180;
	}
}
