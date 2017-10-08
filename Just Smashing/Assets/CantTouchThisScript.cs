using UnityEngine;
using System.Collections;

public class CantTouchThisScript : MonoBehaviour {

    public GameObject P1;
    public GameObject P2;
    public float x;
    public float y;
    public float z;
    public float xy;
    public float distance;
	public float speed;
	public AudioSource Audio;
	public bool AudioPlaying = false;
	public bool Reset = false;
	public float RealSpeed;
	public int Divisor;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        x = P1.transform.localPosition.x - P2.transform.localPosition.x;
        y = P1.transform.localPosition.y - P2.transform.localPosition.y;
        z = P1.transform.localPosition.z - P2.transform.localPosition.z;
        xy = (x * x) + (y * y);
        distance = xy + (z * z);
        distance = Mathf.Sqrt(distance);
		speed = P1.GetComponent<Rigidbody> ().velocity.magnitude;
		if (distance < 100 && speed > 90 && !AudioPlaying && Reset) {
			AudioPlaying = true;
			Debug.Log("Can't Touch This Activated!");
			Audio.Play ();
			Time.timeScale = 0.3f;
			Reset = false;
		}
		if (!Audio.isPlaying) {
			AudioPlaying = false;
			Time.timeScale = 1;

		}
		if (distance > 100) {
			Reset = true;
		}
		RealSpeed = speed / Divisor;

    }
}
