using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    private GameObject chosenObject;
    bool grabbing = false;
    public KeyCode Enlarge, Shrink, RotateL, RotateR, Move;
    public float RotateSpeed, ScaleSpeed;
    Quaternion tempRotate;
    // Use this for initialization
    void Start()
    {

    }

    private void FixedUpdate()
    {
        //if (grabbing)
        //{
        //    chosenObject.transform.position = transform.position;

        //    if (Input.GetKey(Enlarge))
        //    {
        //        chosenObject.transform.localScale += new Vector3(ScaleSpeed, ScaleSpeed, ScaleSpeed);
        //    }
        //    if (Input.GetKey(Shrink))
        //    {
        //        chosenObject.transform.localScale -= new Vector3(ScaleSpeed, ScaleSpeed, ScaleSpeed);
        //    }
        //    if (Input.GetKey(RotateL))
        //    {
        //        tempRotate = chosenObject.transform.rotation;
        //        tempRotate.y += RotateSpeed;
        //        chosenObject.transform.rotation = tempRotate;
        //    }
        //    if (Input.GetKey(RotateR))
        //    {
        //        tempRotate = chosenObject.transform.rotation;
        //        tempRotate.y -= RotateSpeed;
        //        chosenObject.transform.rotation = tempRotate;
        //    }
        //}
    }

    private void OnTriggerStay(Collider collision)
    {
        chosenObject = collision.gameObject;
        if (Input.GetKeyUp(Move))
        {
            Grab();
        }
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
            if (Input.GetKey(RotateL))
            {
                tempRotate = chosenObject.transform.rotation;
                tempRotate.y += RotateSpeed;
                chosenObject.transform.rotation = tempRotate;
            }
            if (Input.GetKey(RotateR))
            {
                tempRotate = chosenObject.transform.rotation;
                tempRotate.y -= RotateSpeed;
                chosenObject.transform.rotation = tempRotate;
            }
        }
    }

    void Grab() //toggles if the hand is grabbing an object
    {
        grabbing = !grabbing;
    }
}

