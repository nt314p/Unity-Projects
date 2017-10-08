using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


	public float speed = 200f;
	public float turnSpeed = 200f;

	public static float health = 100f;
	public static float electricity = 1000f;
	public static float forwardVel;
	public static float distance = 0f;
	public static bool dead = false;
	public static bool powerLoss = false;
	public AudioSource powerDown;
	public bool powerDownPlay = false;

	public static float playerZ;

	// obstacle generation
	public GameObject obstacle;
	public float obsZ;
	public float obsX;
	public float obsEveryDist = 20f;
	public float everyDistCounter = 0;
	public float obsOffset = 100f;

	public GameObject electricityPickup;
	public GameObject wrenchPickup;

	public Rigidbody rb;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.angularVelocity = Vector3.zero;
		rb.constraints = RigidbodyConstraints.FreezePositionY;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (!dead && !powerLoss) {
			forwardVel = rb.velocity.z;

			// turning the hovercraft
			transform.eulerAngles = new Vector3 (0, 0, Input.GetAxis ("Horizontal") * -15);

			// moving the hovercraft left and right
			if (Mathf.Abs (rb.velocity.x) < 300) {
				rb.AddForce (Vector3.right * Input.GetAxis ("Horizontal") * 100 * turnSpeed * Time.deltaTime);
			}
			// forward movement
			if (forwardVel < 250) {
				rb.AddRelativeForce (Vector3.forward * speed * 100 * Time.deltaTime);
			}
			
			// spawning objects
			if (everyDistCounter >= obsEveryDist) {
				everyDistCounter = 0;

				// spawning 10 obstacles
				int i;
				for (i = 0; i < 20; i++) {

					// setting x and z of the obstacle
					obsX = Random.Range (-1000, 1000) + transform.position.x;
					obsZ = transform.position.z + obsOffset;

					// spawning obstacle
					Instantiate (obstacle, new Vector3 (obsX, 6, obsZ), Quaternion.identity);

					// electricity
					if (Random.Range (0, 5) == 2) {
						float pX = Random.Range (-1000, 1000) + transform.position.x;
						float pZ = obsZ;
						Instantiate (electricityPickup, new Vector3 (pX, 10f, pZ), Quaternion.identity);
					}

					// wrench
					if (Random.Range (0, 30) == 2) {
						float wX = Random.Range (-1000, 1000) + transform.position.x;
						float wZ = obsZ;
						Instantiate (wrenchPickup, new Vector3 (wX, 10f, wZ), Quaternion.identity);
					}

					playerZ = transform.position.z;
				}
				Debug.Log ("Generated Layer " + playerZ);
			}

			float distThisFrame = forwardVel * Time.deltaTime;
			everyDistCounter += distThisFrame;

			// adding distance
			distance += distThisFrame;

			// taking away electricity
			electricity -= 18f * Time.deltaTime;

			if (health <= 0) {
				dead = true;
				Death ();
			}

			if (electricity <= 0) {
				powerLoss = true;
				PowerLoss ();
			}

			// setting player's y to 5
			transform.position = new Vector3(transform.position.x, 5f, transform.position.z);
		}
	}

	void OnCollisionEnter(Collision other){

		// detecting collisions and deducting health
		if(other.gameObject.CompareTag("obstacle")){
			health -= Mathf.Abs(forwardVel * 0.02f);
		}
	}

	public static void AddElectricity () {

		// electricity pickup
		electricity += 50;

		if (electricity > 1000) {
			electricity = 1000;
		}
	}

	public static void AddHealth(){
		health += 5;

		if (health > 100) {
			health = 100;
		}
	}

	void Death(){
		rb.constraints = RigidbodyConstraints.None;
		rb.AddTorque(Vector3.up*100000f);
		rb.AddTorque(Vector3.right*100000f);
		rb.AddTorque(Vector3.forward*100000f);
	}

	void PowerLoss(){
		if (!powerDownPlay) {
			powerDown.Play ();
			powerDownPlay = true;
		}
		rb.constraints = RigidbodyConstraints.None;
	}

	void OnLevelWasLoaded(){
		health = 100;
		electricity = 1000;
		distance = 0;
		everyDistCounter = 0;
		dead = false;
		powerLoss = false;
		rb = GetComponent<Rigidbody> ();
		rb.angularVelocity = Vector3.zero;
		rb.velocity = Vector3.zero;
		rb.constraints = RigidbodyConstraints.FreezePositionY;
	}


}
