using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour {
    public Vector3 Cameraoffset = new Vector3(0, -5, 5);
    public GameObject hand;
    
	void Start () {
        
    }
	
	void LateUpdate () {

        //Get Y Rotation of hand
        Quaternion handRotation = Quaternion.Euler(0, hand.transform.eulerAngles.y, 0);

        //Get Position of hand
        Vector3 handPos = hand.transform.position;

        //Apply both to Camera
        transform.position = handPos - (handRotation * Cameraoffset);

        //Look at Camera
        transform.LookAt(hand.transform);
    }

}
