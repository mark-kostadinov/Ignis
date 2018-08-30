using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    public float smoothSpeed = 0.3f;

    private Vector3 currentVelocity;
	
	void LateUpdate () {
		if (target.position.y > transform.position.y)
        {
            Vector3 newPosition = new Vector3(transform.position.x, target.position.y, transform.position.z);
            // Smoothen the camera movement to not be so sharp
            transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref currentVelocity, smoothSpeed);
        }
	}
}
