using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindVERTXobj : MonoBehaviour {

    public GameObject collidingObject;
    public Vector3 objectPosition;

    private void OnTriggerEnter(Collision collision)
    {
        collidingObject = collision.gameObject;

        if(collidingObject.tag != "Floor")
        {
            collidingObject.AddComponent<Rigidbody>();
            collidingObject.GetComponent<Rigidbody>().isKinematic = true;
        }

        
    }


}
