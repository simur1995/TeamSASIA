using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour {
    private GameObject chosenObject;
    bool grabbing;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
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
