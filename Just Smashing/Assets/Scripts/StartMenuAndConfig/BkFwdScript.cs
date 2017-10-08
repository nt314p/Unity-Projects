using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BkFwdScript : MonoBehaviour {

	public GameObject FloatHandler;
	public Camera MainCamera;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Back(){

		MainCamera.GetComponent<CameraControllerScript> ().MoveCamera (2);
	}

	public void Forward(){

		MainCamera.GetComponent<CameraControllerScript> ().MoveCamera (1);
	}

}
