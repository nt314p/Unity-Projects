using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VehiclePlayerOne : MonoBehaviour {

    //Lists for the wheels and stuff
    public List<AxleInfoOne> axleInfos;
    public float maxMotorTorque;
    public float maxSteeringAngle;
    public List<WheelCollidersOne> wheel;

    //The vehicle
    public GameObject Car;

    //The Opponent
    public GameObject ptwo;

    //The handler of the FLOATS!!! $(^_^)$
    public GameObject FloatHandler;

    //The Jet Engine and the glow
    public GameObject JetEngineOne;
    public Light JetLightOne;

    //Target Pos for Jet Engine and increment
    float jTarPos = 0;
    float jIncVal = 0;

    //Y and Z modifiers for the jeep
    float jHeight = 0;
    float jBackMod = 0;
    float jStartMod = 0;

    //The gameobject under which the wheels and colliders are
    public GameObject WheelsAndColliders;

    //For the rpm meter
    public float outmotor;

    //The input for the vehicle
    public float inputBoost;

    //For determining which vehicle to appear as CAR: 1, JEEP: 2
    public float whichVehicle;

    //Boost value
    public float boostVal;

    //Meshes of the vehicles!!!
    public Mesh RacecarMesh;
    public Mesh JeepMesh;
    //Values for the wheel: raduis, suspension distance, spring, target position
    //Car: 3, 0.6, 20000, 0.3
    //Jeep: 4, 2, 40000, 0.5
    //The front and back wheels of the vehicles
    public GameObject FrontWheels;
    public GameObject BackWheels;

    //The visual wheels(4)
    public GameObject FRVisual;
    public GameObject FLVisual;
    public GameObject BRVisual;
    public GameObject BLVisual;
    public float carSca = 0.3f;
    public float jeepSca = 0.4f;
    public Vector3 carScale;
    public Vector3 jeepScale;

    //COM is center of mass
    public Vector3 com = new Vector3(0, -6, 0);
    public Rigidbody rb;

    //Jet Engine Renderer <-- Lots of R's
    Mesh rndrr;

    //Slow down var
    float slow;

    // Use this for initialization
    void Start ()
    {

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
        //The Jet Engine Components
        if (inputBoost == 0)
        {
            jTarPos = 0 + jBackMod + jStartMod;
            JetEngineOne.active = false;
            JetLightOne.intensity = 0;
        }
        else
        {
            JetEngineOne.active = true;
            jTarPos = -15.5f+jBackMod;
            JetLightOne.intensity = inputBoost*8;
        }
        

        float motor;
        float steering;

        motor = maxMotorTorque * Input.GetAxis("Vertical");
        steering = maxSteeringAngle * Input.GetAxis("Horizontal");



        outmotor = motor;

        Car.GetComponent<AudioSource>().pitch = 1 + Mathf.Abs(motor / maxMotorTorque / 2);


        foreach (AxleInfoOne axleInfo in axleInfos)
        {
            if (whichVehicle == 2)
            {
                axleInfo.motor = true;
            }
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

        //Appling the boost
        inputBoost = Input.GetAxis("Boost");
        Car.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * boostVal * 2000 * inputBoost);
    }

    public void Update()
    {
        if (JetEngineOne.transform.localPosition.z < jTarPos)
        {
            jIncVal = jIncVal + 0.5f;
            JetEngineOne.transform.localPosition = new Vector3(0, 3.5f+jHeight, jIncVal+jBackMod);
        }
        if (JetEngineOne.transform.localPosition.z > jTarPos)
        {
            jIncVal = jIncVal - 0.5f;
            JetEngineOne.transform.localPosition = new Vector3(0, 3.5f + jHeight, jIncVal + jBackMod);
        }
    }

    public void OnPause()
    {
        Car.GetComponent<Rigidbody>().isKinematic = true;
    }

    public void OnResume()
    {
        Car.GetComponent<Rigidbody>().isKinematic = false;
        Car.GetComponent<Rigidbody>().WakeUp();
    }

    public void ReceiveData(float vBoost, float vWhichVehicle)
    {
        boostVal = vBoost;
        Debug.Log("Player One's Boost set to: " + boostVal);

        //Which Vehicle...MUCH?????
        whichVehicle = vWhichVehicle;
        Debug.Log("Player One's Vehicle Number is: " + whichVehicle);
        DecideTheVehicle();
    }

    public void DecideTheVehicle()
    {
        //Setting the center of mass
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = com;

        //The scales of the cars wheels
        carScale = new Vector3(carSca, carSca, carSca);
        jeepScale = new Vector3(jeepSca, jeepSca, jeepSca);

        if (whichVehicle == 1)
        {//Racecar

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

            //Setting the weight
            rb.mass = 1500;

            //The motor torque
            maxMotorTorque = 40000;

            //The maximum steering angle
            maxSteeringAngle = 40;

            //Setting Jet Engine Params
            jHeight = 0;
            jBackMod = 0;
			jStartMod = 0;

            //The values of the wheel colliders
            foreach (WheelCollidersOne wheelcol in wheel)
            {
                wheelcol.DahWheelz.radius = 3;
                wheelcol.DahWheelz.suspensionDistance = 0.6f;
                /* Not working really...
                var suspSpring = wheelcol.DahWheelz.suspensionSpring;
                suspSpring.spring = 20000;
                suspSpring.targetPosition = 0.3f;
                */

            }


        }

        if (whichVehicle == 2)
        {//Jeep

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

            //Setting the weight: stupid bouncy jeep
            rb.mass = 2500;

            //The motor torque
            maxMotorTorque = 30000;

            //The maximum steering angle
            maxSteeringAngle = 20;

            //Setting Jet Engine Params
            jHeight = -5.5f;
            jBackMod = -4;
			jStartMod = 4;

            //The values of the wheel colliders
            foreach (WheelCollidersOne wheelcol in wheel)
            {
                wheelcol.DahWheelz.radius = 4;
                wheelcol.DahWheelz.suspensionDistance = 1.6f;

            }

        }
    }
}
[System.Serializable]
public class AxleInfoOne
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor;
    public bool steering;
}

[System.Serializable]
public class WheelCollidersOne
{
    public WheelCollider DahWheelz;
}
