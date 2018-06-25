using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour {
    public float RotateAmount;
    private GameObject chosenObject;
    bool grabbing;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButton("Joystick 1 Button 0"))
        {
            Grab();
        }
        if (grabbing)
        {
            chosenObject.transform.position = transform.position;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        chosenObject = collision.gameObject;
    }

    void Grab()
    {
        grabbing = !grabbing;
    }

    //void Rotate(bool rotate)
    //{
    //    chosenObject =
    //}

    //void ButtonMenu(string selection)
    //{
    //    switch (selection)
    //    {
    //        case "Joystick 1 Button 7":
    //            Rotate(false);
    //            break;
    //        case "Joystick 1 Button 8":
    //            Rotate(true);
    //            break;
    //        default:
    //            break;
    //    }
    //}
}

