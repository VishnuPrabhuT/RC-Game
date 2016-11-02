using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class MyCarScript : MonoBehaviour {


    public GameObject wheel_LF;
    public GameObject wheel_LR;
    public GameObject wheel_RF;
    public GameObject wheel_RR;
    public Text speedText;
    public WheelCollider LF;
    public WheelCollider LR;
    public WheelCollider RF;
    public WheelCollider RR;
    public Rigidbody rb;
    Vector3 tmp;
    public float CarSpeed;


    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        tmp = rb.centerOfMass;
        tmp = new Vector3(0, -0.2f, 0.0f);

	
	}
	
	// Update is called once per frame
	void Update () {
        speedText.text = "Speed: " + CarSpeed; 

    }
    void FixedUpdate()
    { Move_Car();
        SteerWheels();
        RotateWheel();
    }

    void Move_Car()
    { RR.motorTorque = 7000 * Input.GetAxis("Vertical");
        LR.motorTorque = 7000 * Input.GetAxis("Vertical");
        LF.steerAngle = 40 * Input.GetAxis("Horizontal");
        RF.steerAngle = -40 * Input.GetAxis("Horizontal");
    }

    void SteerWheels()
    {
        tmp = wheel_LF.transform.localEulerAngles;
        tmp.y = LF.steerAngle;
        wheel_LF.transform.localEulerAngles = tmp;

        tmp = wheel_RF.transform.localEulerAngles;
        tmp.y = -RF.steerAngle;
        wheel_RF.transform.localEulerAngles = tmp;
    }

    void RotateWheel()
    { wheel_LR.transform.Rotate(0, (LR.rpm / 60) * 360 * Time.deltaTime, 0);
        wheel_RR.transform.Rotate(0, (RR.rpm / 60) * 360 * Time.deltaTime, 0);
        CarSpeed = RR.rpm/60 * Time.deltaTime;
    }
}
