using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VertexUnityPlayer;

public class MessageManager : MonoBehaviour {
    private string lastMessage;
    NodeLink NL;
    List<string> heldGO;
    string tempguid;
    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {

    }

    void Grabbed(string guid)
    {
        tempguid = guid;
        Debug.Log("REVEIVED");
        NL.Fire("OnlineGrab", guid);
        lastMessage = "OnlineGrab";
        Debug.Log("SENT");
    }

    void Dropped(string guid)
    {
        lastMessage = "Dropped";
        GetComponent<NodeLink>().Fire("OnlineDrop", guid);
        
    }

    void OnlineGrab(string guid)
    {
        if(tempguid != guid)
        {
            heldGO.Add(guid);
            Debug.Log("RECEIVED");
        }

    }

    void OnlineDrop(string guid)
    {
        if(tempguid != guid)
        {
            heldGO.Remove(guid);
            tempguid = null;
        }
    }

    void NodeLink_Loaded()
    {
        NL = GetComponent<NodeLink>();
        Debug.Log("Loaded");
        Grabbed("1234");
        GameObject parent = transform.parent.gameObject;
        Debug.Log(parent);
        heldGO = ObjectMovement.heldGO;
 
        //GameObject.Find("Player").GetComponent<ObjectMovement>()
    }

    //TODO get method name
    void newconnention() //placeholder name
    {
        if(lastMessage == "OnlineGrab")
        {
            //NL.Fire(OnlineGrab);
        }
    }

}
