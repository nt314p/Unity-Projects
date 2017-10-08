using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class FloatHandlerScript : MonoBehaviour {
	
	public Canvas StartMenu;
	public float ScreenNum = 2;
	public float ArenaNum = 1;
	public float VehicleNum = 1;
    public float VehicleNumTwo = 1;
	public float P1Boost;
	public float P2Boost;
	public float P1SCR;
	public float P2SCR;


	// Use this for initialization
	void Start () {

		StartMenu = StartMenu.GetComponent<Canvas> ();
		Load (); 
		StartMenu.GetComponent<StartMenuScript>().UpdateScoreText();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ChangeFloats (float type, float number, float secondnumber){

		if (type == 1) {

			ScreenNum = number;
		}

		if (type == 2) {
			
			ArenaNum = number;
		}

		if (type == 3) {
			if (secondnumber == 1)
            {
                VehicleNum = number;
            }
            else
            {
                VehicleNumTwo = number;
            }
			
            
		}

		if (type == 4) {
			
			P1Boost = number;
		}

		if (type == 5) {
			
			P2Boost = number;
		}
	}

    public void ResetHighscores() 
    {
        P1SCR = 0;
        P2SCR = 0;
        Save();
    }

	public void Save(){
		
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/playerScores.dat");

		PlayerScores data = new PlayerScores ();

		data.P1Boost = P1Boost;
		data.P2Boost = P2Boost;
		data.P1SCR = P1SCR;
		data.P2SCR = P2SCR;
        data.VehicleNum = VehicleNum;
        data.VehicleNumTwo = VehicleNumTwo;
        data.ArenaNum = ArenaNum;

		bf.Serialize (file, data);
		file.Close ();
        StartMenu.GetComponent<StartMenuScript>().UpdateScoreText();
        Debug.Log ("Saved");
	}

	public void Load(){

		if (File.Exists (Application.persistentDataPath + "/playerScores.dat")) {

			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/playerScores.dat", FileMode.Open);
			PlayerScores data = (PlayerScores)bf.Deserialize (file);
			

			P1SCR = data.P1SCR;
            P2SCR = data.P2SCR;
            P1Boost = data.P1Boost;
            P2Boost = data.P2Boost;
            ArenaNum = data.ArenaNum;
            VehicleNum = data.VehicleNum;
            VehicleNumTwo = data.VehicleNumTwo;
            file.Close();
            StartMenu.GetComponent<StartMenuScript>().UpdateScoreText();
			Debug.Log ("Loaded");
		} else {

			FirstPlay();
			Debug.Log ("LOAD_Saved");
		}
	}

	public void FirstPlay(){

		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/playerScores.dat");
		
		PlayerScores data = new PlayerScores ();
		
		data.P1Boost = 50;
		data.P2Boost = 50;
		
		data.P1SCR = 0;
		data.P2SCR = 0;

        data.ArenaNum = 1;
        data.VehicleNum = 1;
		
		bf.Serialize (file, data);
		file.Close ();
		Debug.Log ("First Save!");
	}
}

[Serializable]
class PlayerScores{
	
	public float P1Boost;
	public float P2Boost;
	public float P1SCR;
	public float P2SCR;
    public float ArenaNum;
    public float VehicleNum;
    public float VehicleNumTwo;
}

