using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour {

    public GameObject hand;
    public Vector3 offset = new Vector3(0,-5,5);
    
	void Start () {
        
    }
	
	void LateUpdate () {

        //Get Y Rotation of hand
        Quaternion handRotation = Quaternion.Euler(0, hand.transform.eulerAngles.y, 0);

        //Get Position of hand
        Vector3 handPos = hand.transform.position;

        //Apply both to Camera
        transform.position = handPos - (handRotation * offset);

        //Look at Camera
        transform.LookAt(hand.transform);
    }
}
