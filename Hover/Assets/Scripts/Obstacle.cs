using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

	public float l;
	public float w;
	public float h;

	// Use this for initialization
	void Start () {
		l = Random.Range (10, 30);
		w = 10; //Random.Range (5, 30);
		h = Random.Range (30, 200);

		transform.localScale = new Vector3 (l, h, w);
		transform.position = new Vector3 (transform.position.x, h / 2 - 6, transform.position.z);

	}

	void Update () {
		if (Player.playerZ > transform.position.z + 150) {
			Destroy (this.gameObject);
		}
		//if (this.GetComponent<Collider> ().bounds.Intersects()) {
			
		//}

	}

	void OnCollisionEnter(Collision other){
		Debug.Log ("Obstacle Inside (AKA POTATO)");
		if (other.gameObject.CompareTag ("obstacle")) {
			Destroy (this.gameObject);
		}
	}

}
