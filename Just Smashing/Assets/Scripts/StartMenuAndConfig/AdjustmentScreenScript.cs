using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AdjustmentScreenScript : MonoBehaviour {

	public GameObject FloatHandler;
	public Camera MainCamera;
	public Canvas AdjustmentScreen;
	public Button BackButton;
	public Button ForwardButton;
	public Slider P1BoostSlider;
	public Slider P2BoostSlider;
	public Text P1BoostText;
	public Text P2BoostText;

	
	// Use this for initialization
	void Start () {
		
		AdjustmentScreen = AdjustmentScreen.GetComponent<Canvas> ();
		BackButton = BackButton.GetComponent<Button> ();
		ForwardButton = ForwardButton.GetComponent<Button> ();
		P1BoostSlider = P1BoostSlider.GetComponent<Slider> ();
		P2BoostSlider = P2BoostSlider.GetComponent<Slider> ();
        P1BoostSliderChanged();
        P2BoostSliderChanged();
		Disable ();
	}
	
	public void enable(){
		
		BackButton.enabled = true;
		ForwardButton.enabled = true;
		P1BoostSlider.enabled = true;
		P2BoostSlider.enabled = true;
	}
	
	public void Disable(){
		
		BackButton.enabled = false;
		ForwardButton.enabled = false;
		P1BoostSlider.enabled = false;
		P2BoostSlider.enabled = false;
	}
	
	public void P1BoostSliderChanged() {
		
		FloatHandler.GetComponent<FloatHandlerScript> ().ChangeFloats (4, P1BoostSlider.value, 0);
		P1BoostText.text = P1BoostSlider.value.ToString();
	}
	
	public void P2BoostSliderChanged() {
		
		FloatHandler.GetComponent<FloatHandlerScript> ().ChangeFloats (5, P2BoostSlider.value, 0);
		P2BoostText.text = P2BoostSlider.value.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (MainCamera.transform.position.x == 1500) {
			
			enable ();
		} else {
			
			Disable ();
		}
	}

	public void NextScene (){

		FloatHandler.GetComponent<FloatHandlerScript> ().Save ();
		Debug.Log ("Next Scene!!!");
		Application.LoadLevel (2);
	}
}
