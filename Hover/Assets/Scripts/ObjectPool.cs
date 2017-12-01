using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {

	// the object pool
	GameObject[,] objPool;

	public GameObject obstacle;
	GameObject Player;

	float forwardVel; // the velocity of the player

	// obstacle generation
	float obsX;
	float obsZ;
	float obsOffset = 1000;
	float obsRange = 3000; // the left or right maximum spawn 
	public float obsEveryDist = 200f;
	public float everyDistCounter = 0;
	float distThisFrame;

	int obsDensity = 60; // 
	int rowNum = 0; // 0 - 6 is 1 - 7

	void Start () {
		// filling object pool
		objPool = new GameObject[obsDensity,7];
		Player = GameObject.FindGameObjectWithTag ("Player");

		for (int i = 0; i < obsDensity; i++) {
			for (int j = 0; j < 7; j++) {
				objPool [i,j] = Instantiate(obstacle, new Vector3(0, 0, -1000), Quaternion.identity);

			}
		}
	}
	
	// Update is called once per frame
	void Update () {

		forwardVel = Player.GetComponent<Rigidbody>().velocity.z;


		// spawning objects
		if (everyDistCounter >= obsEveryDist) {
			everyDistCounter = 0;
			spawnRow ();
		}

		distThisFrame = Mathf.Round (100 * forwardVel * Time.deltaTime) / 100f;
		everyDistCounter += distThisFrame;
	}

	public void spawnRow(){
		for (int i = 0; i < obsDensity; i++) {
			// setting x and z of the obstacle
			obsX = Random.Range (-obsRange, obsRange) + Player.transform.position.x;
			obsZ = Player.transform.position.z + obsOffset;

			// spawning obstacle
			objPool[i, rowNum].transform.position = new Vector3 (obsX, 6, obsZ);
			objPool[i, rowNum].transform.rotation = Quaternion.identity;
			Player.GetComponent<Player> ().CreateObstacle ();
		}

		rowNum++;

		if (rowNum >= 7) {
			rowNum = 0;
		}
	}
}
