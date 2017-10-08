using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VehicleWinController : MonoBehaviour {

    public GameObject PlayerOne;
    public GameObject PlayerTwo;
    public bool anybodyWon = false;
    public Text WinnerText;
    public Canvas PauseMenu;
    public bool paused;
    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (!anybodyWon)
        {
            if (PlayerOne.transform.localPosition.y < 0)
            {
                Debug.Log("Player Two Wins!");
                anybodyWon = true;
                WinnerText.color = new Color(1, 0, 0, 1);
                WinnerText.text = "Player Two Wins!";
                
                PauseMenu.GetComponent<PauseMenuScript>().Enable();

            }

            if(PlayerTwo.transform.localPosition.y < 0)
            {
                Debug.Log("Player One Wins!");
                anybodyWon = true;
                WinnerText.color = new Color(0, 0, 1, 1);
                WinnerText.text = "Player One Wins!";
                PauseMenu.GetComponent<PauseMenuScript>().Enable();
            }


            float escape = Input.GetAxisRaw("Cancel");
            if (escape == 1)
            {
                paused = true;
                PauseMenu.GetComponent<PauseMenuScript>().Pause();
            }
       
        }

	}

}
