using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicThirdPersonCamera : MonoBehaviour {


    public GameObject playerObject;
    public Vector3 cameraOffset;


    void Start () {

        cameraOffset = gameObject.transform.position - playerObject.transform.position;
            
    }

    void Update () {

        transform.rotation = Quaternion.FromToRotation(Vector3.back, cameraOffset);
    }
	

    void LateUpdate()
    {
        /*
        fixedOffset = playerObject.transform.position + gameObject.transform.position;
        gameObject.transform.position = fixedOffset;
        */
        //gameObject.transform.LookAt(playerObject.transform.position);

        /*
        Vector3 direction = new Vector3(0, 0, - distanceFromPlayer);
        rotation = Quaternion.Euler(0, 0, 0);
        gameObject.transform.position = lookAt.position + rotation * direction;

        gameObject.transform.LookAt(lookAt.position);

    */


    }


}
