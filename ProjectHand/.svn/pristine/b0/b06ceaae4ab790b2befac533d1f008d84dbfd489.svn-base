using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballCamera : MonoBehaviour {


    public GameObject handObject;
    Vector3 offset;
    public float damping = 1;



	// Use this for initialization
	void Start () {
        offset = handObject.transform.position - transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void LateUpdate()
    {
        float currentAngle = transform.eulerAngles.y;
        float desiredAngle = handObject.transform.eulerAngles.y;
        float angle = Mathf.LerpAngle(currentAngle, desiredAngle, Time.deltaTime * damping);

        Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
        transform.position = handObject.transform.position - (rotation * offset);

        transform.LookAt(handObject.transform);
    }
}
