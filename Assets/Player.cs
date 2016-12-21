using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {
    Rigidbody rigidBody;
    private float forceMultiplier = 1000;

	void Start () {
        rigidBody = GetComponent<Rigidbody>();
	}
	
	void Update () {
        Debug.Log("H: " + CrossPlatformInputManager.GetAxis("Horizontal"));
        Debug.Log("V: " + CrossPlatformInputManager.GetAxis("Vertical"));

        if (CrossPlatformInputManager.GetAxis("Horizontal") != 0f) {
            rigidBody.AddForce(Vector3.forward * CrossPlatformInputManager.GetAxis("Horizontal") * forceMultiplier * Time.deltaTime);
        }
	}
}
