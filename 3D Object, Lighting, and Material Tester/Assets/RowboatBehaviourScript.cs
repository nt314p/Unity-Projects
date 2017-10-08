using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowboatBehaviourScript : MonoBehaviour {

	public float targetPosZ;
	public float rowForce = 10f;
	public float moveDist = -10f;
	public float t = 0.1f; // closer to 1: more intense row
	                       // closer to 0: less intense row

	// Use this for initialization
	void Start () {
		targetPosZ = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonUp(0)) {
			targetPosZ = transform.position.z + moveDist; //moving the target position 10 units forward
		}
		this.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * rowForce * Mathf.Lerp(transform.position.z, targetPosZ, t));
	}
}
