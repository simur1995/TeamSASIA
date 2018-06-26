using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    private GameObject chosenObject;
    bool grabbing = false;
    public KeyCode Enlarge, Shrink, RotateL, RotateR, MoveObject;
    public float RotateSpeed, ScaleSpeed;
    public int snapDegrees;
    Quaternion tempRotate;
    // Use this for initialization
    void Start()
    {

    }

    private void FixedUpdate()
    {
        if (grabbing)
        {
            chosenObject.transform.position = transform.position;

            if (Input.GetKey(Enlarge))
            {
                chosenObject.transform.localScale += new Vector3(ScaleSpeed, ScaleSpeed, ScaleSpeed);
            }
            if (Input.GetKey(Shrink))
            {
                chosenObject.transform.localScale -= new Vector3(ScaleSpeed, ScaleSpeed, ScaleSpeed);
            }
            if (Input.GetKeyDown(RotateL))
            {
                /* tempRotate = chosenObject.transform.rotation;
                 tempRotate.y += RotateSpeed;
                 chosenObject.transform.rotation = tempRotate;*/

                //snap to degrees
                chosenObject.transform.Rotate(new Vector3(0, -snapDegrees, 0));
            }
            if (Input.GetKeyDown(RotateR))
            {
                /* tempRotate = chosenObject.transform.rotation;
                 tempRotate.y -= RotateSpeed;
                 chosenObject.transform.rotation = tempRotate;*/

                //snap to degrees
                chosenObject.transform.Rotate(new Vector3(0, snapDegrees, 0));
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

