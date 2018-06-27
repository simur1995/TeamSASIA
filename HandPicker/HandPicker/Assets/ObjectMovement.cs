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
    Material previous;
    public Material publicShader;

    
    private void Update()
    {
        //if (chosenObject != null)
        //{
        //    if (chosenObject.GetComponent<Renderer>() == null)
        //    {
        //        chosenObject.AddComponent<Renderer>();
        //    }
        //    else
        //    {
        //        previous = chosenObject.GetComponent<Renderer>().material.shader;
        //    }
        //}

        CanSnap();

        if (grabbing)
        {
            //chosenObject.GetComponent<MeshRenderer>().material.shader = Shader.Find("ToonLitOutline");
            chosenObject.GetComponent<MeshRenderer>().material = publicShader;
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
<<<<<<< HEAD
=======
            //Rotation Z axis
            if (Input.GetKey(KeyCode.Joystick1Button2) && Input.GetAxis("Left Trigger") > 0)
            {
                chosenObject.transform.Rotate(new Vector3(0, 0, -SnapDegrees));
            }
            if (Input.GetKey(KeyCode.Joystick1Button2) && Input.GetAxis("Right Trigger") > 0)
            {
                chosenObject.transform.Rotate(new Vector3(0, 0, SnapDegrees));
            }
>>>>>>> 974cec6c99b82c38487805de0b141399609fdd43

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
<<<<<<< HEAD
            if (chosenObject != null)
            {
                if (chosenObject.GetComponent<MeshRenderer>() == null)
                {
                    chosenObject.AddComponent<MeshRenderer>();
                }
                else
                {
                    previous = chosenObject.GetComponent<MeshRenderer>().material;
                }
            }
=======
            //while(chosenObject.GetComponent<MeshRenderer>() == null)
            //{
            //}
            //chosenRenderer = chosenObject.GetComponentInChildren<MeshRenderer>();
            //previous = chosenRenderer.material;
            //matArray[0] = previous;
            //matArray[1] = publicShader;
            //chosenRenderer.materials = matArray;
            //if (chosenObject != null)
            //{
            //    if (chosenObject.GetComponent<MeshRenderer>() == null)
            //    {
            //        chosenObject.AddComponent<MeshRenderer>();
            //    }
            //    else
            //    {
            //        previous = chosenObject.GetComponent<MeshRenderer>().material;
            //    }
            //}
>>>>>>> 974cec6c99b82c38487805de0b141399609fdd43
        }
    }

    void Grab() //toggles if the hand is grabbing an object
    {
        if (grabbing)
        {
            //if (previous != null)
            //{
            //    matArray[1] = previous;
            //    chosenObject.GetComponent<MeshRenderer>().materials = matArray;
            //}
            RaycastHit hitinfo;
            Physics.Raycast(chosenObject.transform.position, Vector3.down, out hitinfo);
            chosenObject.transform.position = hitinfo.point;
            
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

