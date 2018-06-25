using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaling : MonoBehaviour {
    GameObject item;
    void OnCollisionEnter(Collision other)
    {
        item = other.gameObject;        
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Joystick1Button2))
        {
            item.gameObject.transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
        }
        if (Input.GetKey(KeyCode.Joystick1Button3))
        {
            item.gameObject.transform.localScale -= new Vector3(0.01f, 0.01f, 0.01f);
        }

    }
}
