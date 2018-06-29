using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    float MOVESPEED = 5;
    float ROTSPEED = 60;
    Quaternion tempRotate;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 left = new Vector3(0, 0, Vector3.forward.z+90);
        Vector3 right =  new Vector3(0, 0, Vector3.forward.z - 90);

        //side movement
        if (Input.GetAxis("Horizontal") < -0.5 )
        {

            transform.Translate(Time.deltaTime * MOVESPEED * Vector3.left);
        }
        if (Input.GetAxis("Horizontal") > 0.5 )
        {

            transform.Translate(Time.deltaTime * MOVESPEED * Vector3.right);
        }

        if (Input.GetAxis("Vertical") < -0.5 )
        {
            //transform.position += Vector3.forward * Time.deltaTime * SPEED;

            transform.Translate(Time.deltaTime * MOVESPEED * Vector3.forward);
        }
        if (Input.GetAxis("Vertical") > 0.5 )
        {
            //transform.position += Vector3.back * Time.deltaTime * SPEED;

            transform.Translate(Time.deltaTime * MOVESPEED *Vector3.back);
        }


        //updown
        if (Input.GetAxis("LeftBumper") > 0.5)
        {
            transform.Translate(Time.deltaTime * MOVESPEED * Vector3.down);
        }
        if (Input.GetAxis("RightBumper") > 0.5)
        {
            transform.Translate(Time.deltaTime * MOVESPEED * Vector3.up);
        }

        //Rotation
        if (Input.GetAxis("LeftHorizontal") < -0.5)
        {

            transform.Rotate(new Vector3(0, Time.deltaTime * -ROTSPEED, 0));
        }
        if (Input.GetAxis("LeftHorizontal") >0.5)
        {

            transform.Rotate(new Vector3(0, Time.deltaTime * ROTSPEED, 0));
        }
    }
}