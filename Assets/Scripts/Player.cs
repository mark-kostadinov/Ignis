using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour {

    Rigidbody2D body;
    public static bool freezeMovement = false;

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!freezeMovement)
        {
            transform.Translate(Input.acceleration.x, 0, 0);
        }
	}
}
