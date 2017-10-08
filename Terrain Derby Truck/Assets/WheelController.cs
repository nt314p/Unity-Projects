using UnityEngine;
using System.Collections;

public class WheelController : MonoBehaviour {

	public GameObject PleaseSpecify;
	// Use this for initialization

	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = PleaseSpecify.transform.position;
		transform.eulerAngles = PleaseSpecify.transform.eulerAngles;
	}
}