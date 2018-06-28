using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VertexUnityPlayer;

public class Messages : MonoBehaviour {
    public List<string> heldGO = new List<string>();
    private string lastMessage;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    void Grabbed(string guid)
    {
        NodeLink grabbedNL = GameObject.Find(guid).GetComponent<NodeLink>();
        heldGO.Add(guid);
        grabbedNL.Fire("OnlineGrab", guid);
        lastMessage = "OnlineGrab";
        Debug.Log("SENT");
    }

    void Dropped(NodeLink grabbedNL)
    {
        lastMessage = "Dropped";
        heldGO.Remove(grabbedNL.Guid);
        grabbedNL.Fire("OnlineGrab", grabbedNL);
    }

    void OnlineGrab(string guid)
    {
        heldGO.Add(guid);
        Debug.Log("RECEIVED");
    }

    void OnlineDrop(NodeLink NL)
    {

    }

}
