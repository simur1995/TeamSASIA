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

            //transform.position += Vector3.left * Time.deltaTime * SPEED;

            transform.Rotate(new Vector3(0, Time.deltaTime * -ROTSPEED, 0));
        }
        if (Input.GetAxis("Horizontal") > 0 )
        {
            Debug.Log("Rightarrow detected!");

            //transform.position += Vector3.right * Time.deltaTime * SPEED;

            transform.Rotate(new Vector3(0, Time.deltaTime * ROTSPEED, 0));
        }

        if (Input.GetAxis("Vertical") > 0 )
        {
            Debug.Log("Rightarrow detected!");
            //transform.position += Vector3.forward * Time.deltaTime * SPEED;

            transform.Translate(Time.deltaTime * MOVESPEED * Vector3.forward);
        }
        if (Input.GetAxis("Vertical") < 0 )
        {
            Debug.Log("Rightarrow detected!");
            //transform.position += Vector3.back * Time.deltaTime * SPEED;

            transform.Translate(Time.deltaTime * MOVESPEED *Vector3.back);
        }

        if (Input.GetKey(KeyCode.Joystick1Button4))
        {
            Debug.Log("Leftarrow detected!");
            transform.position += Vector3.up * Time.deltaTime * MOVESPEED;
        }

         if (Input.GetKey(KeyCode.Joystick1Button5))
        {
            Debug.Log("Leftarrow detected!");
            transform.position += Vector3.down * Time.deltaTime * MOVESPEED;
        }
    }
}