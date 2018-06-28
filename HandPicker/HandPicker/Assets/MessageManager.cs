using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VertexUnityPlayer;

public class MessageManager : MonoBehaviour {
    public List<string> heldGO = new List<string>();
    private string lastMessage;
    // Use this for initialization
    void Start() {
        GameObject.Find("SceneLink").AddComponent<NodeLink>();
    }

    // Update is called once per frame
    void Update() {

    }

    void Grabbed(string guid)
    {
        Debug.Log("REVEIVED");
        NodeLink grabbedNL = GameObject.Find(guid).GetComponent<NodeLink>();
        heldGO.Add(guid);
        GameObject.Find("SceneLink").GetComponent<NodeLink>().Fire("OnlineGrab", guid);
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

}
