using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landscape : MonoBehaviour {

    private GameObject chosenObject;

    void Start () {
		
	}
    
    private void OnTriggerStay(Collider collision)
    {
        chosenObject = collision.gameObject;
        if (Input.GetKey("space") && chosenObject.transform.position.y <=2)
        {
            chosenObject.transform.position += Vector3.up * Time.deltaTime * 2;
        }
    }
}
