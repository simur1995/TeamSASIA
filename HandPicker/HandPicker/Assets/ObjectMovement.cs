using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour {


    private GameObject chosenObject;
    bool grabbing;
    
	void Update () {
        //grabbed object has same values as hand
        if (grabbing)
        {
            chosenObject.transform.position = transform.position;
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        chosenObject = collision.gameObject;
    }

    void Grab()
    {
        grabbing = !grabbing;
    }
}
