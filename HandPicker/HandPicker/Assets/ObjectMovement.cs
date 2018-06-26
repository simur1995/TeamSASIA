using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    private GameObject chosenObject;
    bool grabbing = false;
    public KeyCode Scale, Rotate, MoveObject;
    public float ScaleSpeed, SnapDegrees;
    // Use this for initialization
    void Start()
    {

    }

    private void FixedUpdate()
    {
        if (grabbing)
        {
            chosenObject.transform.position = transform.position;

            //if (Input.GetKey(Enlarge))
            //{
            //    chosenObject.transform.localScale += new Vector3(ScaleSpeed, ScaleSpeed, ScaleSpeed);
            //}
            //if (Input.GetKey(Shrink))
            //{
            //    chosenObject.transform.localScale -= new Vector3(ScaleSpeed, ScaleSpeed, ScaleSpeed);
            //}
            //if (Input.GetAxis("Right Trigger") < 0)
            //{
            //    /* tempRotate = chosenObject.transform.rotation;
            //     tempRotate.y += RotateSpeed;
            //     chosenObject.transform.rotation = tempRotate;*/

            //    //snap to degrees
            //    chosenObject.transform.Rotate(new Vector3(0, -snapDegrees, 0));
            //}
            //if (Input.GetAxis("Left Trigger") > 0)
            //{
            //    /* tempRotate = chosenObject.transform.rotation;
            //     tempRotate.y -= RotateSpeed;
            //     chosenObject.transform.rotation = tempRotate;*/

            //    //snap to degrees
            //    chosenObject.transform.Rotate(new Vector3(0, snapDegrees, 0));
            //}
            if(Input.GetKey(Scale) && Input.GetAxis("Right Trigger") > 0)
            {
                chosenObject.transform.localScale += new Vector3(ScaleSpeed, ScaleSpeed, ScaleSpeed);
            }
            if(Input.GetKey(Rotate) && Input.GetAxis("Right Trigger") > 0)
            {
                chosenObject.transform.Rotate(new Vector3(0, SnapDegrees, 0));
            }
            if (Input.GetKey(Scale) && Input.GetAxis("Left Trigger") > 0)
            {
                chosenObject.transform.localScale -= new Vector3(ScaleSpeed, ScaleSpeed, ScaleSpeed);
            }
            if(Input.GetKey(Rotate) && Input.GetAxis("Left Trigger") > 0)
            {
                chosenObject.transform.Rotate(new Vector3(0, -SnapDegrees, 0));
            }

        }
    }

    private void OnTriggerStay(Collider collision)
    {
        chosenObject = collision.gameObject;
        if (Input.GetKeyUp(MoveObject))
        {
            Grab();
        }
    }

    void Grab() //toggles if the hand is grabbing an object
    {
        grabbing = !grabbing;
    }
}

