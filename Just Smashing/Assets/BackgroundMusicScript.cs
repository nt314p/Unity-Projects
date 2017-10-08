using UnityEngine;
using System.Collections;

public class BackgroundMusicScript : MonoBehaviour {

    public GameObject BackgroundMusic;
    public GameObject PauseMenu;
    public float audVol;
    public float audTemp;
    public AudioSource Audio;
	public GameObject CantTouchThis;

	// Use this for initialization
	void Start () {
        Audio = BackgroundMusic.GetComponent<AudioSource>();
		Audio.volume = 0.4f;//PauseMenu.GetComponent<PauseMenuScript>().VolumeMod;
		audVol = Audio.volume;
		audTemp = audVol;

    }
	
	// Update is called once per frame
	void Update () {
        audTemp = PauseMenu.GetComponent<PauseMenuScript>().VolumeMod;
        if (audTemp < audVol)
        {
            audVol = audVol - 0.03f;
        }
		else if (audTemp == audVol)
        {
            audVol = PauseMenu.GetComponent<PauseMenuScript>().VolumeMod;
        }
        //audVol = PauseMenu.GetComponent<PauseMenuScript>().VolumeMod*0.5f;
		if (CantTouchThis.GetComponent<CantTouchThisScript> ().AudioPlaying) {
			Audio.volume = 0;
		} else {
			Audio.volume = audVol;
		}
	}

	public void playerDied () {
		Audio.volume = 0.3f;
	}
}
