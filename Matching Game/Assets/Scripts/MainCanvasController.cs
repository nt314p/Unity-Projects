using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainCanvasController : MonoBehaviour {

	public Canvas HelpCanvas;
	public Canvas SettingsCanvas;
	public Canvas QuitCanvas;
	public Dropdown Difficulty;
		
	// Use this for initialization
	void Start () {
		HelpCanvas.enabled = false;
		SettingsCanvas.enabled = false;
		QuitCanvas.enabled = false;
		Difficulty.value = PlayerPrefs.GetInt ("Difficulty");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlayButton () {
		Application.LoadLevel (1);
	}

	public void HelpButton () {
		HelpCanvas.enabled = true;
	}

	public void HelpCloseButton () {
		HelpCanvas.enabled = false;
	}

	public void SettingsButton () {
		SettingsCanvas.enabled = true;
	}

	public void SettingsCloseButton () {
		SettingsCanvas.enabled = false;
	}

	public void QuitButton () {
		QuitCanvas.enabled = true;
	}

	public void QuitYesButton () {
		Application.Quit ();
	}

	public void QuitNoButton () {
		QuitCanvas.enabled = false;
	}

	public void SettingsDropdown () {

		if (!PlayerPrefs.HasKey ("Difficulty")) {
			Debug.Log ("First time setting difficulty");
		}
		PlayerPrefs.SetInt ("Difficulty", Difficulty.value);

		Debug.Log ("Difficulty selection changed to: " + PlayerPrefs.GetInt("Difficulty"));

		PlayerPrefs.Save ();
	}
}
