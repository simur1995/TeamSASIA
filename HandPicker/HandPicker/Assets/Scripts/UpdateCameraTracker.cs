using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateCameraTracker : MonoBehaviour {

    public GameObject playerObject;
    public GameObject cameraObject;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame


    void LateUpdate()
    {
        gameObject.transform.position = playerObject.transform.position;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.transform.Rotate(Vector3.down * Time.deltaTime * 100);
        }

        if (Input.GetKey(KeyCode.RightArrow))

        {
            gameObject.transform.Rotate(Vector3.up * Time.deltaTime * 100);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            gameObject.transform.Rotate(Vector3.left * Time.deltaTime * 100);
        }

        if (Input.GetKey(KeyCode.UpArrow))

        {
            gameObject.transform.Rotate(Vector3.right * Time.deltaTime * 100);
        }

        cameraObject.transform.LookAt(playerObject.transform);
    }

}
