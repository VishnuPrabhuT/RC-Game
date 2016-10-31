using UnityEngine;
using System.Collections;

public class ThirdPersonFollow : MonoBehaviour {
    public Transform target;
    public float damping = 6.0f;
    public bool smooth = true;
    public float minDistance = 10.0f;
    public float offset = 1, offsety = 1;
    public float speed = 1.0f;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
        if (smooth)
        {
            //Camforward, lookat, up=yaxis
            Quaternion rotation = Quaternion.LookRotation(target.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
        }
        else
        {
            transform.rotation = Quaternion.FromToRotation(-Vector3.forward, (new Vector3(target.position.x, target.position.y, target.position.z) - transform.position).normalized);
            float distance = Vector3.Distance(target.position, transform.position);
        }
        Vector3 cameraOffset = target.forward * offset;
        //Vector3 newPos = new Vector3(target.position.x - offsetx, target.position.y - offsety, target.position.z - offsetz);
        Vector3 newPos = target.position - cameraOffset;
        //set height 
        newPos.y += offsety;
        //transform.position = newPos;
        transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * speed);

    }
}
