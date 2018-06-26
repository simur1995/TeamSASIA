using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinScript : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        GameObject trash = collision.gameObject;
        if (trash.tag == "Rubbish")
        {
            Debug.Log("Rubbish Detected!");
            trash.GetComponent<Renderer>().enabled = false;
        }
    }
}
