using UnityEngine;
using System.Collections;

public class TorusExplosionScript : MonoBehaviour {

	public GameObject T1;
	public GameObject T2;
	public GameObject T3;
	public GameObject T4;
	public GameObject T5;
	public GameObject T6;
	public GameObject T7;
	public GameObject T8;
	public GameObject T9;
	public GameObject T10;
	public GameObject T11;
	public GameObject T12;
	public GameObject T13;
	public GameObject T14;
	public GameObject T15;
	public GameObject T16;
	public GameObject Torus;
	public GameObject Poof;
	public GameObject Text;
	public float done = 0;
	public float radius = 20.0F;
	public float power = 20.0F;
	Vector3 Place = new Vector3 (-5, -1, 0);
	Vector3 TextPlace = new Vector3 (0, 15, 0);

	// Use this for initialization
	void Start () {

	}

	IEnumerator GenAndExplode (){

		//Making the torus parts not kinematic
		T1.GetComponent<Rigidbody> ().isKinematic = false;
		T2.GetComponent<Rigidbody> ().isKinematic = false;
		T3.GetComponent<Rigidbody> ().isKinematic = false;
		T4.GetComponent<Rigidbody> ().isKinematic = false;
		T5.GetComponent<Rigidbody> ().isKinematic = false;
		T6.GetComponent<Rigidbody> ().isKinematic = false;
		T7.GetComponent<Rigidbody> ().isKinematic = false;
		T8.GetComponent<Rigidbody> ().isKinematic = false;
		T9.GetComponent<Rigidbody> ().isKinematic = false;
		T10.GetComponent<Rigidbody> ().isKinematic = false;
		T11.GetComponent<Rigidbody> ().isKinematic = false;
		T12.GetComponent<Rigidbody> ().isKinematic = false;
		T13.GetComponent<Rigidbody> ().isKinematic = false;
		T14.GetComponent<Rigidbody> ().isKinematic = false;
		T15.GetComponent<Rigidbody> ().isKinematic = false;
		T16.GetComponent<Rigidbody> ().isKinematic = false;

		//Generating the broken torus
		T1.transform.rotation = Quaternion.Euler (270, 0, 0);
		T1.transform.position = new Vector3 (0, 4, 0);

		T2.transform.rotation = Quaternion.Euler (270, 0, 45);
		T2.transform.position = new Vector3 (0, 4, 0);

		T3.transform.rotation = Quaternion.Euler (270, 0, 90);
		T3.transform.position = new Vector3 (0, 4, 0);

		T4.transform.rotation = Quaternion.Euler (270, 0, 135);
		T4.transform.position = new Vector3 (0, 4, 0);

		T5.transform.rotation = Quaternion.Euler (270, 0, 180);
		T5.transform.position = new Vector3 (0, 4, 0);

		T6.transform.rotation = Quaternion.Euler (270, 0, 225);
		T6.transform.position = new Vector3 (0, 4, 0);

		T7.transform.rotation = Quaternion.Euler (270, 0, 270);
		T7.transform.position = new Vector3 (0, 4, 0);

		T8.transform.rotation = Quaternion.Euler (270, 0, 315);
		T8.transform.position = new Vector3 (0, 4, 0);
		
		T9.transform.rotation = Quaternion.Euler (-270, 180, 0);
		T9.transform.position = new Vector3 (0, 4, 0);

		T10.transform.rotation = Quaternion.Euler (-270, 180, 45);
		T10.transform.position = new Vector3 (0, 4, 0);

		T11.transform.rotation = Quaternion.Euler (-270, 180, 90);
		T11.transform.position = new Vector3 (0, 4, 0);

		T12.transform.rotation = Quaternion.Euler (-270, 180, 135);
		T12.transform.position = new Vector3 (0, 4, 0);

		T13.transform.rotation = Quaternion.Euler (-270, 180, 180);
		T13.transform.position = new Vector3 (0, 4, 0);

		T14.transform.rotation = Quaternion.Euler (-270, 180, 225);
		T14.transform.position = new Vector3 (0, 4, 0);

		T15.transform.rotation = Quaternion.Euler (-270, 180, 270);
		T15.transform.position = new Vector3 (0, 4, 0);
	
		T16.transform.rotation = Quaternion.Euler (-270, 180, 315);
		T16.transform.position = new Vector3 (0, 4, 0);

		Place = new Vector3 (Random.Range(-6F, -4F), -1, Random.Range(-1F, 1F));

		//The Collider Explosion
		Poof.transform.position = Place;

		//Put the text in place
		Text.transform.position = TextPlace;
		yield return new WaitForSeconds (3);
		Application.LoadLevel (1);
	}

	


	// Update is called once per frame
	void Update () {
	
		if (done == 0) {

			if(Torus.transform.position.y < 5){

				//Destroy torus
				Destroy(Torus);
				StartCoroutine ("GenAndExplode");
				done = 1;

			}
				
		
		}
	}
}
