﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VertexUnityPlayer;

public class ObjectMovement : MonoBehaviour
{
    private GameObject chosenObject;
    static public bool grabbing = false;
    public KeyCode Scale, Rotate, MoveObject;
    public float ScaleSpeed, SnapDegrees;
    bool snapBool = true;
    public Material publicMaterial;
    private Material[] matArray = new Material[2];
    private Renderer[] chosenRenderer;
    Material[] previous;
    Transform initialPosition;
    Vector3 worldPosition;

    private void Update()
    {

        CanSnap();

        if (grabbing)
        {
            if (Input.GetKeyDown(KeyCode.Joystick1Button6))
            {
                chosenObject.transform.localRotation = initialPosition.localRotation;
                chosenObject.transform.localScale = initialPosition.localScale;
                chosenObject.transform.position = worldPosition;

                Debug.Log("Back pressed!");
                Grab();

                return;
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
        
        if (collision2.name == "Plane")
        {
            return;
        }
        initialPosition = collision2.transform;
        worldPosition = collision2.transform.gameObject.transform.position;

        //highlight
        var tempGO = collision2.gameObject;
        while(tempGO.transform.parent.name != "SceneLink")
        {
            tempGO = tempGO.transform.parent.gameObject;
        }
        chosenRenderer = tempGO.GetComponentsInChildren<MeshRenderer>();
        if(chosenRenderer[0].material != publicMaterial)
        {
            previous = new Material[chosenRenderer.Length];
            for (int i = 0; i < chosenRenderer.Length; i++)
            {
                previous[i] = chosenRenderer[i].material;
            }
            for (int i = 0; i < previous.Length; i++)
            {
                publicMaterial.color = previous[i].color;
                chosenRenderer[i].material = publicMaterial;
            }
        }
        //Debug.Log((initialPosition.transform.position).ToString());
    }

    private void OnTriggerExit(Collider other)
    {
        for (int i = 0; i < chosenRenderer.Length; i++)
        {
            chosenRenderer[i].material = previous[i];
        }
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
            while (chosenObject.GetComponent<NodeLink>() == null && chosenObject.tag != "EditorOnly")
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

