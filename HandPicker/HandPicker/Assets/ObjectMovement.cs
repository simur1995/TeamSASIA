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
    bool snapBool = true;
    Shader previous;

    
    private void Update()
    {
        if (chosenObject != null)
        {
            if (chosenObject.GetComponent<Renderer>() == null)
            {
                chosenObject.AddComponent<Renderer>();
            }
            else
            {
                previous = chosenObject.GetComponent<Renderer>().material.shader;
            }
        }

        CanSnap();

        if (grabbing)
        {
            chosenObject.GetComponent<Renderer>().material.shader = Shader.Find("Toon/Lit-Outline");
            //position
            chosenObject.transform.position = transform.position;
            
            //Scaling
            if (Input.GetKey(Scale) && Input.GetAxis("Right Trigger") > 0)
            {
                chosenObject.transform.localScale += new Vector3(ScaleSpeed, ScaleSpeed, ScaleSpeed);
            }
            if (Input.GetKey(Scale) && Input.GetAxis("Left Trigger") > 0)
            {
                chosenObject.transform.localScale -= new Vector3(ScaleSpeed, ScaleSpeed, ScaleSpeed);
            }

            //Rotation
            if(Input.GetKey(Rotate) && Input.GetAxis("Left Trigger") > 0)
            {
                chosenObject.transform.Rotate(new Vector3(0, -SnapDegrees, 0));
            }
            if (Input.GetKey(Rotate) && Input.GetAxis("Right Trigger") > 0)
            {
                chosenObject.transform.Rotate(new Vector3(0, SnapDegrees, 0));
            }

            //Rotation With Snap


            if (Input.GetAxis("Left Trigger") > 0)
            {
                if (Input.GetKey(Rotate))
                {
                    chosenObject.transform.Rotate(new Vector3(0, -SnapDegrees, 0));
                }
                else
                {
                    if (snapBool && !(Input.GetKey(Scale)))
                    {
                        chosenObject.transform.Rotate(new Vector3(0, 45, 0));
                        snapBool = false;
                        
                    }
                }
            }
            if (Input.GetAxis("Right Trigger") > 0)
            {
                if (Input.GetKey(Rotate))
                {
                    chosenObject.transform.Rotate(new Vector3(0, SnapDegrees, 0));
                }
                else
                {
                    if (snapBool && !(Input.GetKey(Scale)))
                    {
                        chosenObject.transform.Rotate(new Vector3(0, -45, 0));
                        snapBool = false;
                        if (Input.GetAxis("Right Trigger") < 0.2)
                        {
                            snapBool = true;
                        }
                    }
                }
            }
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (Input.GetKeyUp(MoveObject) && chosenObject.tag != "EditorOnly" )
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
            if (previous != null)
            {
                chosenObject.GetComponent<Renderer>().material.shader = previous;
            }
        }
        grabbing = !grabbing;
    }

    void CanSnap()
    {
        if (Input.GetAxis("Left Trigger") < 0.1 && Input.GetAxis("Right Trigger") < 0.1)
        {
            snapBool = true;
        }
    }
}

