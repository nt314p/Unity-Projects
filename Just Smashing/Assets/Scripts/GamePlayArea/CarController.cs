using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class CarController : MonoBehaviour
{
    public List<AxleInfo> axleInfos;
    public float maxMotorTorque;
    public float maxSteeringAngle;
    public List<WheelColliders> wheel;

    //The gameobject this script is attatched to.
    public GameObject Car;
    public GameObject WheelsAndColliders;

    //Whom is player1??????
    public bool isPlayerOne;

    //COM is center of mass
    public Vector3 com = new Vector3(0, -5, 0);
    public Rigidbody rb;
    public float whichVehicle;

    //The Handler of the Floats
    public GameObject FloatHandler;

    //Whheel stuff
    public float outmotor;
    public float outsteering;

    //Meshes of the vehicles!!!
    public Mesh RacecarMesh;
    public Mesh JeepMesh;
    //Values for the wheel: raduis, suspension distance, spring, target position
    //Car: 3, 0.6, 20000, 0.3
    //Jeep: 4, 2, 40000, 0.5
    //The front and back wheels of the vehicles
    public GameObject FrontWheels;
    public GameObject BackWheels;

    //BOOST -->>>>>>>>OVAH 9000
    public float boostVal = 0;//!!!!!!!!!!!!!!THIS VALUE IS TEMPORARY
    public float inputBoost;

    //The visual wheels(4)
    public GameObject FRVisual;
    public GameObject FLVisual;
    public GameObject BRVisual;
    public GameObject BLVisual;
    public float carSca = 0.3f;
    public float jeepSca = 0.4f;
    public Vector3 carScale;
    public Vector3 jeepScale;


    void Start()
    {
       
        //Setting the center of mass
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = com;

        //The scales of the cars wheels
        carScale = new Vector3(carSca, carSca, carSca);
        jeepScale = new Vector3(jeepSca, jeepSca, jeepSca);

        //The rumbly engine noises
        AudioSource audio = Car.GetComponent<AudioSource>();


        //Determine which vehicle to appear as :)

        //Player2
        if (!isPlayerOne)
        {
            whichVehicle = FloatHandler.GetComponent<FloatLoader>().VehicleNumTwo;
            boostVal = FloatHandler.GetComponent<FloatLoader>().P2Boost;
            Debug.Log("Player Two's Boost set to: " + boostVal);
        }
        //Player1
        if (isPlayerOne)
        {
            whichVehicle = FloatHandler.GetComponent<FloatLoader>().VehicleNum;
            boostVal = FloatHandler.GetComponent<FloatLoader>().P2Boost;
            Debug.Log("Player One's Boost set to: " + boostVal);
        }
        whichVehicle = 1;
        
        if (whichVehicle == 1){//Racecar

            //Setting the appearence of the car
            Car.GetComponent<MeshFilter>().mesh = RacecarMesh;
            Car.GetComponent<MeshCollider>().sharedMesh = RacecarMesh;

            //Moving the axes and such
            WheelsAndColliders.transform.localPosition = new Vector3(0, 0.6f, 0);
            FrontWheels.transform.localPosition = new Vector3(0, 0, 12);
            BackWheels.transform.localPosition = new Vector3(0, 0, -8);

            //Setting the scale of the visuals
            FRVisual.transform.localScale = carScale;
            FLVisual.transform.localScale = carScale;
            BRVisual.transform.localScale = carScale;
            BLVisual.transform.localScale = carScale;

            //The motor torque
            maxMotorTorque = 40000;

            //The values of the wheel colliders
            foreach (WheelColliders wheelcol in wheel)
            {
                wheelcol.DahWheelz.radius = 3;
                wheelcol.DahWheelz.suspensionDistance = 0.6f;
                var suspSpring = wheelcol.DahWheelz.suspensionSpring;
                suspSpring.spring = 20000;
                suspSpring.targetPosition = 0.3f;
        
            }
            

        }
        
        if (whichVehicle == 2){//Jeep

            //Setting the appearence of the car
            Car.GetComponent<MeshFilter>().mesh = JeepMesh;
            Car.GetComponent<MeshCollider>().sharedMesh = JeepMesh;
            WheelsAndColliders.transform.localPosition = new Vector3(0, -7, 0);
            FrontWheels.transform.localPosition = new Vector3(0, 0, 13.2f);
            BackWheels.transform.localPosition = new Vector3(0, 0, -12.9f);

            //Setting the scale of the visuals
            FRVisual.transform.localScale = jeepScale;
            FLVisual.transform.localScale = jeepScale;
            BRVisual.transform.localScale = jeepScale;
            BLVisual.transform.localScale = jeepScale;

            //Setting the center of mass
            rb = GetComponent<Rigidbody>();
            rb.centerOfMass = com;

            //The motor torque
            maxMotorTorque = 30000;


            //The values of the wheel colliders
            foreach (WheelColliders wheelcol in wheel)
            {
                wheelcol.DahWheelz.radius = 4;
                wheelcol.DahWheelz.suspensionDistance = 1.6f;
                var suspSpring = wheelcol.DahWheelz.suspensionSpring;
                suspSpring.spring = 40000;
                suspSpring.targetPosition = 0.5f;

            }

        }
        

        
    }


    // finds the corresponding visual wheel
    // correctly applies the transform
    public void ApplyLocalPositionToVisuals(WheelCollider collider)
    {
        if (collider.transform.childCount == 0)
        {
            return;
        }

        Transform visualWheel = collider.transform.GetChild(0);

        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }

    public void FixedUpdate()
    {

        float motor;
        float steering;

        //float engineFilter;
        if (isPlayerOne)
        {

            motor = maxMotorTorque * Input.GetAxis("Vertical");
            steering = maxSteeringAngle * Input.GetAxis("Horizontal");
            
        }
        else
        {

            motor = maxMotorTorque * Input.GetAxis("VerticalTwo");
            steering = maxSteeringAngle * Input.GetAxis("HorizontalTwo");
        }

        outmotor = motor;

        Car.GetComponent<AudioSource>().pitch = 1 + Mathf.Abs(motor/maxMotorTorque/2);


        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
            ApplyLocalPositionToVisuals(axleInfo.leftWheel);
            ApplyLocalPositionToVisuals(axleInfo.rightWheel);
        }
       
        if (isPlayerOne)
        {
            inputBoost = Input.GetAxisRaw("Boost");

        }else if(!isPlayerOne)
        {
            inputBoost = Input.GetAxisRaw("BoostTwo");

        }

        Car.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * boostVal * 10000 * inputBoost);
    }
}
[System.Serializable]
public class AxleInfo {
	public WheelCollider leftWheel;
	public WheelCollider rightWheel;
	public bool motor;
	public bool steering;
}

[System.Serializable]
public class WheelColliders
{
    public WheelCollider DahWheelz;
}
