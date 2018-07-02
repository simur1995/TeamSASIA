using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAnim : MonoBehaviour {

    Animator anim;
    
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	void Update () {
        

        if (ObjectMovement.grabbing)
        {
            anim.SetBool("IsGrabbing", true);
        }
        else
        {
            anim.SetBool("IsGrabbing", false);
        }
    }


}
