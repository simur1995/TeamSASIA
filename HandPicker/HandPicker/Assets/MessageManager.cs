using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VertexUnityPlayer;


public class MessageManager : MonoBehaviour {
    private string lastMessage;
    NodeLink NL;
    string tempguid;
    public string userid;
    public Dictionary<string, string> NameAndID;
    private string tempViewPoint;
    List<string> heldGO;
    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {

    }

    //this method takes a string organised as method,guid,viewpointid then creates a type metadata using last two and used the first to call the correct method
    //void LocalMessageManage(string message) 
    //{
    //    string[] temp = message.Split(',');
    //    MetaData fireData = new MetaData();
    //    fireData.guid = temp[1];
    //    fireData.viewpointid = userid;
    //    NL.SendMessage(temp[0], fireData);

    //}

    void Grabbed(string guid)
    {
        tempguid = guid;
        NL.Fire("OnlineGrab", guid);
        lastMessage = "OnlineGrab";
        Debug.Log("SENT");
    }

    void Dropped(string guid)
    {
        lastMessage = "Dropped";
        NL.Fire("OnlineDrop", guid);   
    }

    void OnlineGrab(string guid)
    {
        if(tempguid != guid && !heldGO.Contains(guid))
        {
            heldGO.Add(guid);
            Debug.Log("RECEIVED");
        }

    }

    void OnlineDrop(string guid)
    {
        if(guid != tempguid)
        {
            heldGO.Remove(guid);
        }
    }

    void NodeLink_Loaded()
    {
        NL = GetComponent<NodeLink>();
        Debug.Log("Loaded");
        heldGO = ObjectMovement.heldGO;
        NL.Fire("nameupdate", userid);
        NameAndID = new Dictionary<string, string>();
 
        //GameObject.Find("Player").GetComponent<ObjectMovement>()
    }

    void nameupdate(string userid)
    {
        NameAndID.Add(tempViewPoint, userid);
    }

    //TODO get method name
    void ConnectPlaceHolder(string id) //connect placeholder
    {
        if(lastMessage == "OnlineGrab")
        {
            NL.Fire(lastMessage, tempguid);
        }

        tempViewPoint = id;
    }

    //TODO get methood name
    void DisconnectPlaceHolder(string disconnectid) //disconnect placeholder
    {
    }
}
