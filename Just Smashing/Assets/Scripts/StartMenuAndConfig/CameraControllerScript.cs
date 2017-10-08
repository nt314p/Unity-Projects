using UnityEngine;
using System.Collections;

public class CameraControllerScript : MonoBehaviour {

	public Camera MainCamera;
	public float RotateSpeed;
	public int speed = 50;
	public float multi;
	public float OutSitu;
	public float oldX;
	public float SceneNum;
	public bool Once = true;
	//int CngeFunc = 0;
	public GameObject FloatHandler;
	int i = 0;

	// Use this for initialization
	void Start () {
		MainCamera = MainCamera.GetComponent<Camera> ();
	}

	public void MoveCamera (float situ){
		Debug.Log ("MoveCamera function called!");
		/*situ numbers
		 * 1 StartScreen to ArenaScreen
		 * 2 ArenaScreen to VehicleScreen
		 * 3 VehicleScreen to AdjustScreen
		 * 4 HelpScreen
		*/
		OutSitu = situ;
		i = 0;
		oldX = transform.position.x;
		Once = true;
		/*
		if (situ == 1) {

			CngeFunc = 1;
		}
		if (situ == 2) {

			CngeFunc = 2;
		}
		*/
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		//Forward
		if(OutSitu == 1){

			if(Once){

				MainCamera.GetComponent<SoundScript>().MovingSound(1);
				Once = false;
			}

			if(i < 500){

				i = i + speed;
				Vector3 position = new Vector3(oldX+i, 133f, -111);
				transform.position = position;
			}
			if (i == 500){

				OutSitu = 0;
				FloatHandler.GetComponent<FloatHandlerScript> ().ChangeFloats (1, FloatHandler.GetComponent<FloatHandlerScript> ().ScreenNum + 1, 0);
			}



		}
		//Backward
		if(OutSitu == 2){

			if(Once){
				
				MainCamera.GetComponent<SoundScript>().MovingSound(2);
				Once = false;
			}
			if(i < 500){

				i = i + speed;
				Vector3 position = new Vector3(oldX-i, 133f, -111);
				transform.position = position;
			}
			if (i == 500){

				OutSitu = 0;
				FloatHandler.GetComponent<FloatHandlerScript> ().ChangeFloats (1, FloatHandler.GetComponent<FloatHandlerScript> ().ScreenNum - 1, 0);
			}

		
		}
		/*
		//Function function!!!:
		//CngeFunc corosponds to OutSitu
		if (CngeFunc == 1) {


			CngeFunc = 0;
		}
		if (CngeFunc == 2) {


			CngeFunc = 0
		}
		*/

	}
}