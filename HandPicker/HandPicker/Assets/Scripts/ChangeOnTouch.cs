using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeOnTouch : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        
        GameObject collidingObject = collision.gameObject;

        if(collidingObject.tag == "Collidable" || collidingObject.tag == "Trash")
        {
            collidingObject.GetComponent<Renderer>().enabled = false;
        }

        
    }
}
