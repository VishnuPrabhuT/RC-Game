using UnityEngine;
using System.Collections;

public class ThirdPersonCamera : MonoBehaviour
{

    public GameObject Car;

    private Vector3 offset;
    private Transform target;
    private float distance = 7.0f;
    private float height = 3.0f;
    private float damping = 5.0f;
    public bool smoothRotation = true;
    public bool followCar = true;
    public float rotationDamping = 10.0f;

    // Use this for initialization
    void Start()
    {
        target = Car.transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPosition;
        if (followCar)
        {
            newPosition = target.TransformPoint(0, height, -distance);
        }
        else
        {
            newPosition = target.TransformPoint(0, height, distance);
        }
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * damping);

        if (smoothRotation)
        {
            Quaternion wantedRotation = Quaternion.LookRotation(target.position - transform.position, target.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, wantedRotation, Time.deltaTime * rotationDamping);
        }
        else
        {
            transform.LookAt(target, target.up);
        }
    }


}