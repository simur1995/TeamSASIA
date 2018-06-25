using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    //public float speed;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (Input.GetAxis("Horizontal") < 0 || Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("Leftarrow detected!");
            transform.position += Vector3.right * Time.deltaTime * 10;
        }

        if (Input.GetAxis("Horizontal") > 0 )
        {
            Debug.Log("Rightarrow detected!");
            transform.position += Vector3.left * Time.deltaTime * 10;
        }
        if (Input.GetAxis("Vertical") > 0 )
        {
            Debug.Log("Rightarrow detected!");
            transform.position += Vector3.forward * Time.deltaTime * 10;
        }
        if (Input.GetAxis("Vertical") < 0 )
        {
            Debug.Log("Rightarrow detected!");
            transform.position += Vector3.back * Time.deltaTime * 10;
        }
        if (Input.GetKey(KeyCode.Joystick1Button4))
        {
            Debug.Log("Leftarrow detected!");
            transform.position += Vector3.up * Time.deltaTime * 10;
        }
         if (Input.GetKey(KeyCode.Joystick1Button5))
        {
            Debug.Log("Leftarrow detected!");
            transform.position += Vector3.down * Time.deltaTime * 10;
        }
    }
}