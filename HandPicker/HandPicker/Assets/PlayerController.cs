using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    float SPEED = 10;
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
            transform.position += Vector3.left * Time.deltaTime * SPEED;
        
        }

        if (Input.GetAxis("Horizontal") > 0 )
        {
            Debug.Log("Rightarrow detected!");
            transform.position += Vector3.right * Time.deltaTime * SPEED;
        }
        if (Input.GetAxis("Vertical") > 0 )
        {
            Debug.Log("Rightarrow detected!");
            transform.position += Vector3.forward * Time.deltaTime * SPEED;
        }
        if (Input.GetAxis("Vertical") < 0 )
        {
            Debug.Log("Rightarrow detected!");
            transform.position += Vector3.back * Time.deltaTime * SPEED;
        }
        if (Input.GetKey(KeyCode.Joystick1Button4))
        {
            Debug.Log("Leftarrow detected!");
            transform.position += Vector3.up * Time.deltaTime * SPEED;
        }
         if (Input.GetKey(KeyCode.Joystick1Button5))
        {
            Debug.Log("Leftarrow detected!");
            transform.position += Vector3.down * Time.deltaTime * SPEED;
        }
    }
}