using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class StartMenuScript : MonoBehaviour {

	public GameObject FloatHandler;
	public Canvas exitMenu;
	public Button startButton;
	public Button helpButton;
	public Button exitButton;
	public Text scoreText1;
	public Text scoreText2;
	public Camera MainCamera;

	// Use this for initialization
	void Start () {

		exitMenu = exitMenu.GetComponent<Canvas> ();
		startButton = startButton.GetComponent<Button> ();
		helpButton = helpButton.GetComponent<Button> ();
		exitButton = exitButton.GetComponent<Button> ();
		exitMenu.enabled = false;

	}

	public void UpdateScoreText(){

		scoreText1.text = "P1: " + FloatHandler.GetComponent<FloatHandlerScript> ().P1SCR; 
		scoreText2.text = "P2: " + FloatHandler.GetComponent<FloatHandlerScript> ().P2SCR; 
	}

	public void ExitPress(){

		exitMenu.enabled = true;
		startButton.enabled = false;
		helpButton.enabled = false;
		exitButton.enabled = false;

	}

	public void NoPress(){

		exitMenu.enabled = false;
		startButton.enabled = true;
		helpButton.enabled = true;
		exitButton.enabled = true;
	}

	public void StartPress(){

		MainCamera.GetComponent<CameraControllerScript> ().MoveCamera (1);
		//FloatHandler.GetComponent <FloatHandlerScript> ().FHSceneChange(2);
		//FloatHandler.GetComponent<FloatHandlerScript> ().ChangeFloats (1, 3);
		disable ();
	}

	public void HelpPress(){

		MainCamera.GetComponent<CameraControllerScript> ().MoveCamera (2);		
		//FloatHandler.GetComponent <FloatHandlerScript> ().FHSceneChange(1);
		//FloatHandler.GetComponent<FloatHandlerScript> ().ChangeFloats (1, 1);
		disable ();
	}

	public void ExitGame(){

		Application.Quit ();
	}

	public void enable(){

		startButton.enabled = true;
		helpButton.enabled = true;
		exitButton.enabled = true;
	}

	public void disable(){

		startButton.enabled = false;
		helpButton.enabled = false;
		exitButton.enabled = false;
	}




	// Update is called once per frame
	void Update () {

		if (MainCamera.transform.position.x == 0) {

			enable ();
		} else {
				
			disable ();
		}
	}
}
