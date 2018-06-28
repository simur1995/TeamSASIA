using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VertexUnityPlayer;

public class MessageManager : MonoBehaviour {
    public List<string> heldGO = new List<string>();
    private string lastMessage;
    NodeLink NL;
    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {

    }

    void Grabbed(string guid)
    {
        Debug.Log("REVEIVED");
        heldGO.Add(guid);
        NL.Fire("OnlineGrab", guid);
        lastMessage = "OnlineGrab";
        Debug.Log("SENT");
    }

    void Dropped(string guid)
    {
        lastMessage = "Dropped";
        heldGO.Remove(guid);
        GetComponent<NodeLink>().Fire("OnlineDrop", guid);
        
    }

    void OnlineGrab(string guid)
    {
        heldGO.Add(guid);
        Debug.Log("RECEIVED");
    }

    void OnlineDrop(string guid)
    {
        heldGO.Remove(guid);
    }

    void NodeLink_Loaded()
    {
        NL = GetComponent<NodeLink>();
        Debug.Log("Loaded");
        Grabbed("1234");
        //GameObject.Find("Player").GetComponent<ObjectMovement>()
    }

}
