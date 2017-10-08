using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseMenuScript : MonoBehaviour
{

	public Canvas PauseMenu;
	public float VolumeMod = 1;
	public GameObject RestartButtonB;
	public GameObject ResumeButtonB;
	public Text PauseMenuText;
	public GameObject P1;
	public GameObject P2;
	public Rigidbody P1r;
	public Rigidbody P2r;
	public Vector3 P1savedVel;
	public Vector3 P1savedAngVel;
	public Vector3 P2savedVel;
	public Vector3 P2savedAngVel;
	public bool paused = false;


	// Use this for initialization
	void Start ()
	{
		Disable ();
		RestartButtonB.active = true;
		ResumeButtonB.active = false;

	}

	public void Disable ()
	{
		resetScale ();
		PauseMenuText.enabled = false;
		PauseMenu.enabled = false;
		VolumeMod = 0.4f;
	}

	public void Enable ()
	{
		resetScaleShow ();
		PauseMenuText.enabled = true;
		PauseMenu.enabled = true;
		VolumeMod = 0.1f;
	}

	public void Pause ()
	{
		resetScaleShow ();
		Debug.Log ("Paused");
		PauseMenu.enabled = true;
		PauseMenuText.enabled = true;
		P1.GetComponent<VehiclePlayerOne> ().OnPause ();
		P2.GetComponent<VehiclePlayerTwo> ().OnPause ();
		P1savedVel = P1r.velocity;
		P1savedAngVel = P1r.angularVelocity;
		P2savedVel = P2r.velocity;
		P2savedAngVel = P2r.angularVelocity;
		RestartButtonB.active = false;
		ResumeButtonB.active = true;

	}

	
	// Update is called once per frame
	void Update ()
	{
       
	}

	public void QuitToMenuButton ()
	{
		Application.LoadLevel (1);
		Disable ();
	}

	public void RestartButton ()
	{
		PauseMenu.referencePixelsPerUnit = 20;
		//PauseMenu.referencePixelsPerUnit = 1000;
		Application.LoadLevel (2);
		Disable ();
	}

	public void ExitGameButton ()
	{
		Application.Quit ();
		Disable ();
	}

	public void ResumeButton ()
	{
		P1.GetComponent<VehiclePlayerOne> ().OnResume ();
		P2.GetComponent<VehiclePlayerTwo> ().OnResume ();
		P1r.velocity = P1savedVel;
		P1r.angularVelocity = P1savedAngVel;
		P2r.velocity = P2savedVel;
		P2r.angularVelocity = P2savedAngVel;
		RestartButtonB.active = true;
		ResumeButtonB.active = false;
		Disable ();
	}

	public void resetScale ()
	{
		Image[] image = GetComponentsInChildren<Image>();
		foreach (var c in image) {
			c.GetComponent<Image> ().enabled = false;
		}

	}

	public void resetScaleShow ()
	{
		Image[] image = GetComponentsInChildren<Image>();
		foreach (var c in image) {
			c.GetComponent<Image> ().enabled = true;
		}
	}


}
