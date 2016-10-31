#pragma strict

var wheels : Transform[];
var enginePower=50.0;
var power=0.0;
var brake=0.0;
var steer=0.0;
var maxSteer=25.0;
var forwardgear=false;
var reversegear=false;
var keypressed=0;
var gearstring = "Neutral";
function Start(){
    GetComponent.<Rigidbody>().centerOfMass=Vector3(0,-0.5,0.3);
}
 
function Update ()
{
    if (Input.GetKeyDown("w"))
    {
        keypressed = keypressed + 1;
        if (keypressed >= 1)
            keypressed = 1;
    }
    if (Input.GetKeyDown("z"))
    {
        keypressed = keypressed - 1;
        if (keypressed <= -1)
            keypressed = -1;
    }
    if (keypressed == -1)
    {
        forwardgear = false;
        reversegear = true;
        gearstring = "Reverse";
    }  
    if (keypressed == 0)
    {
        forwardgear = false;
        reversegear = false;
        gearstring = "Neutral";
    }  
    if (keypressed == 1)
    {
        forwardgear = true;
        reversegear = false;
        gearstring = "Forward";
    }  
    if (forwardgear)
    {
        power = Input.GetAxis("Horizontal");
        power = (power + 1) * 0.5;
        power = power * enginePower * Time.deltaTime * 100.0;
        steer=Input.GetAxis("Horizontal") * maxSteer;
        brake=Input.GetAxis("Horizontal");
        brake = (brake +1) * 0.5;
        brake = brake ? GetComponent.<Rigidbody>().mass * 0.05: 0.0;
        GetCollider(0).steerAngle=steer;
        GetCollider(1).steerAngle=steer;
        if(brake > 0.0)
        {
            GetCollider(0).brakeTorque=brake;
            GetCollider(1).brakeTorque=brake;
            GetCollider(2).brakeTorque=brake;
            GetCollider(3).brakeTorque=brake;
            GetCollider(2).motorTorque=0.0;
            GetCollider(3).motorTorque=0.0;
        } else {
            GetCollider(0).brakeTorque=0;
            GetCollider(1).brakeTorque=0;
            GetCollider(2).brakeTorque=0;
            GetCollider(3).brakeTorque=0;
            GetCollider(2).motorTorque=power;
            GetCollider(3).motorTorque=power;
        }
    }
    if (reversegear)
    {
        power = Input.GetAxis("Horizontal");
        power = (power + 1) * 0.5;
        power = -power;
        power = power * enginePower * Time.deltaTime * 50.0;
        steer=Input.GetAxis("Horizontal") * maxSteer;
        brake=Input.GetAxis("Horizontal");
        brake = (brake +1) * 0.5;
        brake = brake ? GetComponent.<Rigidbody>().mass * 0.05: 0.0;
        GetCollider(0).steerAngle=steer;
        GetCollider(1).steerAngle=steer;
        if(brake > 0.0)
        {
            GetCollider(0).brakeTorque=brake;
            GetCollider(1).brakeTorque=brake;
            GetCollider(2).brakeTorque=brake;
            GetCollider(3).brakeTorque=brake;
            GetCollider(2).motorTorque=0.0;
            GetCollider(3).motorTorque=0.0;
        } else {
            GetCollider(0).brakeTorque=0;
            GetCollider(1).brakeTorque=0;
            GetCollider(2).brakeTorque=0;
            GetCollider(3).brakeTorque=0;
            GetCollider(2).motorTorque=power;
            GetCollider(3).motorTorque=power;
        }
    }
 
}
function GetCollider(n : int) : WheelCollider{
    return wheels[n].gameObject.GetComponent(WheelCollider);
}
    function OnGUI () {
        GUI.Label (Rect (10, 10, 100, 20), gearstring);
        GUI.Label (Rect (10, 30, 100, 20), power.ToString());
        GUI.Label (Rect (10, 50, 100, 20), brake.ToString());
    }
 