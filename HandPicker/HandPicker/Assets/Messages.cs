using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Messages : MonoBehaviour {
    public List<object> heldGO = new List<object>();
    private string lastMessage;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    void Grabbed(object grabbedObject)
    {
        heldGO.Add(grabbedObject);
        SendMessageUpwards("OnlineGrab", grabbedObject);
        lastMessage = "OnlineGrab";
    }

    void OnlineGrab(object grabbedObject)
    {
        heldGO.Add(grabbedObject);
    }

    void Dropped()
    {
        lastMessage = "Dropped";
        //heldGO.Remove()
    }

}
