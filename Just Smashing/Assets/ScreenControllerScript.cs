using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScreenControllerScript : MonoBehaviour {

    public GameObject PlayerOne;
    public GameObject PlayerTwo;
    public Image RPMArrowOne;
    public Image RPMArrowTwo;
    public float RotationOne;
    public float RotationTwo;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        RotationOne = PlayerOne.GetComponent<VehiclePlayerOne>().outmotor;
        RotationTwo = PlayerTwo.GetComponent<VehiclePlayerTwo>().outmotor;
        RotationOne = RotationOne / 148;
        RotationTwo = RotationTwo / 148;
        RPMArrowOne.rectTransform.localRotation = Quaternion.Euler(0, 0, (-1*Mathf.Abs(RotationOne)) + 135);
        RPMArrowTwo.rectTransform.localRotation = Quaternion.Euler(0, 0, (-1*Mathf.Abs(RotationTwo)) + 135);
       
    }
}
