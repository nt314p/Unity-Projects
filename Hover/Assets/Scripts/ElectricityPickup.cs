﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricityPickup : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.up, 40 * Time.deltaTime);
		if (Player.playerZ > transform.position.z + 100) {
			Destroy (this.gameObject);
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag("Player")) {
			Player.AddElectricity ();
		}
		Destroy (this.gameObject);
	}
}