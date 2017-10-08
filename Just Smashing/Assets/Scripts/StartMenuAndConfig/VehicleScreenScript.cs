using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VehicleScreenScript : MonoBehaviour {

	public GameObject FloatHandler;
	public Camera MainCamera;
	public Canvas VehicleScreen;
	public Button BackButton;
	public Button ForwardButton;
    public Dropdown PlayerOneDropdown;
    public Dropdown PlayerTwoDropdown;
	
	// Use this for initialization
	void Start () {
		
		VehicleScreen = VehicleScreen.GetComponent<Canvas> ();
		BackButton = BackButton.GetComponent<Button> ();
		ForwardButton = ForwardButton.GetComponent<Button> ();
		PlayerOneDropdown = PlayerOneDropdown.GetComponent<Dropdown> ();
		PlayerTwoDropdown = PlayerTwoDropdown.GetComponent<Dropdown> ();
		
		
		Disable ();
        PlayerOneDropdownChanged();
        PlayerTwoDropdownChanged();
	}
	
	public void enable() {
		
		BackButton.enabled = true;
		ForwardButton.enabled = true;
		PlayerOneDropdown.enabled = true;
		PlayerTwoDropdown.enabled = true;
	}
	
	public void Disable() {
		
		BackButton.enabled = false;
		ForwardButton.enabled = false;
		PlayerOneDropdown.enabled = false;
		PlayerTwoDropdown.enabled = false;
	}
	
	public void PlayerOneDropdownChanged() {
		
		FloatHandler.GetComponent<FloatHandlerScript> ().ChangeFloats (3, PlayerOneDropdown.value + 1, 1);//Add one because of pesky arrays
	}
	
	public void PlayerTwoDropdownChanged() {
		
		FloatHandler.GetComponent<FloatHandlerScript> ().ChangeFloats (3, PlayerTwoDropdown.value + 1, 2);
	}
	
	// Update is called once per frame
	void Update () {
		
		if (MainCamera.transform.position.x == 1000) {
			
			enable ();
		} else {
			
			Disable ();
		}
	}
}

