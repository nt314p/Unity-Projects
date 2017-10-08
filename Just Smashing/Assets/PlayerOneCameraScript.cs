using UnityEngine;
using System.Collections;

public class PlayerOneCameraScript : MonoBehaviour {

	public GameObject Player1;
	public Rigidbody r;
	public Vector3 velocity;
	public Camera P1Camera;

    // Use this for initialization
    void Start () {
		r = Player1.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		velocity = r.velocity;
		P1Camera.transform.forward = velocity;
    }
		
}
