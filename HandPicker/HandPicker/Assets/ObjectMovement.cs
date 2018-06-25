using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public float RotateAmount;
    private GameObject chosenObject;
    bool grabbing = false;
    // Use this for initialization
    void Start()
    {

    }



    private void OnTriggerStay(Collider collision)
    {
        chosenObject = collision.gameObject;
        if (Input.GetKeyUp(KeyCode.Joystick1Button0))
        {
            Debug.Log("pressed");
            Grab();
        }
        if (grabbing)
        {
            chosenObject.transform.position = transform.position;
            if (Input.GetKey(KeyCode.Joystick1Button2))
            {
                chosenObject.transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
            }
            if (Input.GetKey(KeyCode.Joystick1Button3))
            {
                chosenObject.transform.localScale -= new Vector3(0.01f, 0.01f, 0.01f);
            }
        }
    }

    void Grab()
    {
        grabbing = !grabbing;
    }
}

