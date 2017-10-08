using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class FloatLoader : MonoBehaviour {


    public GameObject PlayerOne;
    public GameObject PlayerTwo;

    //Needed defs so no glitch
	public float ArenaNum = 1;
	public float VehicleNum = 1;
    public float VehicleNumTwo = 1;
	public float P1Boost = 50;
	public float P2Boost = 50;
	public float P1SCR;
	public float P2SCR;


	// Use this for initialization
	void Start () {

        

        if (File.Exists(Application.persistentDataPath + "/playerScores.dat"))
        {

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerScores.dat", FileMode.Open);
            PlayerScores data = (PlayerScores)bf.Deserialize(file);
            P1Boost = data.P1Boost;
            P2Boost = data.P2Boost;
            Debug.Log(P1Boost + " and " + P2Boost);
            P1SCR = data.P1SCR;
            P2SCR = data.P2SCR;
            ArenaNum = data.ArenaNum;
            VehicleNum = data.VehicleNum;
            VehicleNumTwo = data.VehicleNumTwo;
            Debug.Log(VehicleNum + " and " + VehicleNumTwo);

            file.Close();
            Debug.Log("Loaded");
            PlayerOne.GetComponent<VehiclePlayerOne>().ReceiveData(P1Boost, VehicleNum);
            PlayerTwo.GetComponent<VehiclePlayerTwo>().ReceiveData(P2Boost, VehicleNumTwo);
        }
    }
	
	// Update is called once per frame
	void Update () {
        
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

            file.Close();
			Debug.Log ("Loaded");
		}
	}

}
/*
[Serializable]
class PlayerScoresL{
	
	public float P1Boost;
	public float P2Boost;
	public float P1SCR;
	public float P2SCR;
    public float ArenaNum;
    public float VehicleNum;
}
*/

