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
        if (Input.GetAxis("Horizontal") < 0 )
        {
            Debug.Log("Leftarrow detected!");

            transform.position += Vector3.left * Time.deltaTime * MOVESPEED;
        }
        if (Input.GetAxis("Horizontal") > 0 )
        {
            Debug.Log("Rightarrow detected!");

            transform.position += Vector3.right * Time.deltaTime * MOVESPEED;
        }

        if (Input.GetAxis("Vertical") < 0 )
        {
            Debug.Log("Forward detected!");
            //transform.position += Vector3.forward * Time.deltaTime * SPEED;

            transform.Translate(Time.deltaTime * MOVESPEED * Vector3.forward);
        }
        if (Input.GetAxis("Vertical") > 0 )
        {
            Debug.Log("Back detected!");
            //transform.position += Vector3.back * Time.deltaTime * SPEED;

            transform.Translate(Time.deltaTime * MOVESPEED *Vector3.back);
        }

        if (Input.GetKey(KeyCode.Joystick1Button4))
        {
            Debug.Log("Leftarrow detected!");
            transform.Translate(Time.deltaTime * MOVESPEED * Vector3.up);
        }
        if (Input.GetKey(KeyCode.Joystick1Button5))
        {
            Debug.Log("Leftarrow detected!");
            transform.Translate(Time.deltaTime * MOVESPEED * Vector3.down);
        }

        if (Input.GetAxis("LeftHorizontal") < 0)
        {
            Debug.Log("LeftRotation detected!");

            transform.Rotate(new Vector3(0, Time.deltaTime * -ROTSPEED, 0));
        }
        if (Input.GetAxis("LeftHorizontal") > 0.2)
        {
            Debug.Log("RightRotation detected!");

            transform.Rotate(new Vector3(0, Time.deltaTime * ROTSPEED, 0));
        }
    }
}