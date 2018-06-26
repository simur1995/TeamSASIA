using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VertexUnityPlayer;

public class FindVERTXobj : MonoBehaviour {

    public GameObject collidingObject;
    public Vector3 objectPosition;

    private void OnCollisionEnter(Collision collision)
    {
        collidingObject = collision.gameObject;
        Debug.Log("Collision!");
        if(collidingObject.tag != "Floor")
        {
            collidingObject.AddComponent<Rigidbody>();
            collidingObject.GetComponent<Rigidbody>().isKinematic = true;
        }

    }


}
