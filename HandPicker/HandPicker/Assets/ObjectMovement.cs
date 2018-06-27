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
    public Material publicMaterial;
    private Material[] matArray = new Material[2];
    private Renderer chosenRenderer;
    Transform initialPosition;

    private void Update()
    {

        CanSnap();

        if (grabbing)
        {
            if (Input.GetKey(KeyCode.Joystick1Button6))
            {
                chosenObject.transform.localRotation = initialPosition.localRotation;
                chosenObject.transform.localScale = initialPosition.localScale;

                Debug.Log("Back pressed!");
                Grab();
                chosenObject.transform.localPosition = initialPosition.localPosition;

            }
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
            if (Input.GetKey(Rotate) && Input.GetAxis("Left Trigger") > 0)
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
                if (Input.GetKey(KeyCode.Joystick1Button2))
                {
                    chosenObject.transform.Rotate(new Vector3(0, 0, -SnapDegrees));
                }
                if (Input.GetKey(Rotate))
                {
                    chosenObject.transform.Rotate(new Vector3(0, -SnapDegrees, 0));
                }
                else
                {
                    if (snapBool && !(Input.GetKey(Scale)) && !(Input.GetKey(KeyCode.Joystick1Button2)))
                    {
                        chosenObject.transform.Rotate(new Vector3(0, 45, 0));
                        snapBool = false;

                    }
                }
            }
            if (Input.GetAxis("Right Trigger") > 0)
            {
                if (Input.GetKey(KeyCode.Joystick1Button2))
                {
                    chosenObject.transform.Rotate(new Vector3(0, 0, SnapDegrees));
                }
                if (Input.GetKey(Rotate))
                {
                    chosenObject.transform.Rotate(new Vector3(0, SnapDegrees, 0));
                }
                else
                {
                    if (snapBool && !(Input.GetKey(Scale)) && !(Input.GetKey(KeyCode.Joystick1Button2)))
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

    private void OnTriggerEnter(Collider collision2)
    {
        chosenRenderer = collision2.GetComponentInChildren<MeshRenderer>();
        previous = chosenRenderer.material;
        publicMaterial.color = previous.color;
        matArray[1] = previous;
        matArray[0] = publicMaterial;
        chosenRenderer.materials = matArray;
        initialPosition = collision2.transform;
    }

    private void OnTriggerExit(Collider other)
    {
        matArray[0] = previous;
        chosenRenderer.materials = matArray;
    }

    private void OnTriggerStay(Collider collision)
    {
        if (Input.GetKeyUp(MoveObject) && chosenObject.tag != "EditorOnly")
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
        if (grabbing && !Input.GetKey(KeyCode.Joystick1Button6))
        {
            raycast();

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

    void raycast()
    {
        RaycastHit hitinfo;
        Physics.Raycast(chosenObject.transform.position, Vector3.down, out hitinfo);
        chosenObject.transform.position = hitinfo.point;
        float moveAmount = chosenObject.transform.position.y - chosenObject.GetComponentInChildren<Collider>().ClosestPointOnBounds(hitinfo.point).y;
        Vector3 newPosition = new Vector3(hitinfo.point.x, chosenObject.transform.position.y - moveAmount, hitinfo.point.z);
        chosenObject.transform.position = newPosition;
    }
}

