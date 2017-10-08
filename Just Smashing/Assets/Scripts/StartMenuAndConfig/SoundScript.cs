using UnityEngine;
using System.Collections;


[RequireComponent(typeof(AudioSource))]


public class SoundScript : MonoBehaviour {

	public AudioClip MoveForSound;
	public AudioClip MoveBackSound;

	// Use this for initialization
	void Start () {



	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void MovingSound(float dir){

		if (dir == 1) {

			AudioSource.PlayClipAtPoint(MoveForSound, transform.position);
		}
		if (dir == 2) {

			AudioSource.PlayClipAtPoint(MoveBackSound, transform.position);
		}

	}
}
