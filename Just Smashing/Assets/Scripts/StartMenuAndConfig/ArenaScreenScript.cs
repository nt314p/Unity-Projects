using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ArenaScreenScript : MonoBehaviour {

	public GameObject FloatHandler;
	public Camera MainCamera;
	public Canvas ArenaScreen;
	public Button BackButton;
	public Button ForwardButton;
	public Button RacetrackButton;
	public Button JumpNBumpButton;

	// Use this for initialization
	void Start () {

		ArenaScreen = ArenaScreen.GetComponent<Canvas> ();
		BackButton = BackButton.GetComponent<Button> ();
		ForwardButton = ForwardButton.GetComponent<Button> ();
		RacetrackButton = RacetrackButton.GetComponent<Button> ();
		JumpNBumpButton = JumpNBumpButton.GetComponent<Button> ();
	

		Disable ();
	}

	public void enable(){

		BackButton.enabled = true;
		ForwardButton.enabled = true;
		RacetrackButton.enabled = true;
		JumpNBumpButton.enabled = true;
	}

	public void Disable(){

		BackButton.enabled = false;
		ForwardButton.enabled = false;
		RacetrackButton.enabled = false;
		JumpNBumpButton.enabled = false;
	}

	public void RacetrackButtonPressed() {

		FloatHandler.GetComponent<FloatHandlerScript> ().ChangeFloats (2, 1, 0);
	}

	public void JumpNBumpButtonPressed() {
		
		FloatHandler.GetComponent<FloatHandlerScript> ().ChangeFloats (2, 2, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
		if (MainCamera.transform.position.x == 500) {

			enable ();
		} else {

			Disable ();
		}
	}
}
