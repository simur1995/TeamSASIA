using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VertexUnityPlayer;

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

    private void Update()
    {
        if (grabbing)
        {
        
            chosenObject.transform.position = transform.position;
            
            //chosenObject.GetComponent<NodeLink>().TargetPosition = transform.position;
            //var comps = chosenObject.GetComponents(typeof());
            //for (int i = 0; i < comps.Length; i++)
            //{
            //    Debug.Log(comps[i].ToString());
            //}


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
            if (Input.GetKey(Scale) && Input.GetAxis("Right Trigger") > 0)
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
        if (Input.GetKeyUp(MoveObject))
        {
            Grab();
        }
        if (!grabbing)
        {
            chosenObject = collision.gameObject;
            while (chosenObject.GetComponent<NodeLink>() == null)
            {
                chosenObject = chosenObject.transform.parent.gameObject;
            }
        }
    }

    void Grab() //toggles if the hand is grabbing an object
    {
        if (grabbing)
        {
            RaycastHit hitinfo;
            Physics.Raycast(chosenObject.transform.position, Vector3.down, out hitinfo);
            chosenObject.transform.position = hitinfo.point;
        }
        grabbing = !grabbing;
    }
}

