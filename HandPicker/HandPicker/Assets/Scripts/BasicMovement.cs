using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour {

    public float movementSpeed = 0.1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Translate(movementSpeed * Vector3.left * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))

        {
            gameObject.transform.Translate(movementSpeed * Vector3.right * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))

        {
            gameObject.transform.Translate(movementSpeed * Vector3.back * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W))

        {
            gameObject.transform.Translate(movementSpeed * Vector3.forward * Time.deltaTime);
        }
    }
}
