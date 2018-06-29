using UnityEngine;
using System.Collections;

public class PlayerRayCasting : MonoBehaviour
{
    public float distanceToSee;
    public string ObjectName;
    private Color highlightColor;
    Material originalMaterial;
    public Material tempMaterial;
    Renderer rend = null;
    public Material usethis;

    void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {
        RaycastHit hitInfo;
        Renderer currRend;

        //Draws ray in scene view during playmode; the multiplication in the second parameter controls how long the line will be
        Debug.DrawRay(this.transform.position, this.transform.forward * distanceToSee, Color.magenta);

        //A raycast returns a true or false value
        //we  initiate raycast through the Physics class
        //out parameter is saying take collider information of the object we hit, and push it out and 
        //store is in the what I hit variable. The variable is empty by default, but once the raycast hits
        //any collider, it's going to take the information, and store it in whatIHit variable. So then,
        //if I wanted to access something, I could access it through the whatIHit variable. 

        if (Physics.Raycast(this.transform.position, this.transform.forward, out hitInfo, distanceToSee))
        {
            currRend = hitInfo.collider.gameObject.GetComponent<Renderer>();

            if (currRend == rend)
                return;

            if (currRend && currRend != rend)
            {
                if (rend)
                {
                    rend.sharedMaterial = originalMaterial;
                }

            }

            if (currRend)
                rend = currRend;
            else
                return;

            originalMaterial = rend.sharedMaterial;

<<<<<<< HEAD
            tempMaterial = new Material(originalMaterial);
=======
            tempMaterial = new Material(usethis);
             
>>>>>>> 4de72dfb9c50abe4ebbf81bbac88cbfeaab6b1f6
            rend.material = tempMaterial;
            rend.material.color = highlightColor;
        }
        else
        {
            if (rend)
            {
                rend.sharedMaterial = originalMaterial;
                rend = null;
            }
        }
    }
}