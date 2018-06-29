using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VertexUnityPlayer;


public class MessageManager : SingletonPattern<MessageManager>
{
    //private string lastMessage;
    //NodeLink NL;
    public string Tempguid;
    public string userid;
    public Dictionary<string, string> NameAndID;
    //private string tempViewPoint;

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
        NodeLink NL = NodeLink.Find(guid);
        Tempguid = guid;
        NL.Fire("OnlineGrab", guid);
        //lastMessage = "OnlineGrab";
        Debug.Log("SENT");
    }

    void Dropped(string guid)
    {
        NodeLink NL = NodeLink.Find(guid);
        //lastMessage = "Dropped";
        NL.Fire("OnlineDrop", guid);   
    }

    //void NodeLink_Loaded()
    //{
    //    NodeLink NL = GameObject.Find(guid).GetComponent<NodeLink>();
    //    Debug.Log("Loaded");
    //    NL.Fire("nameupdate", userid);
    //    NameAndID = new Dictionary<string, string>();
 
    //    //GameObject.Find("Player").GetComponent<ObjectMovement>()
    //}

    //void nameupdate(string userid)
    //{
    //    NameAndID.Add(tempViewPoint, userid);
    //}

    //TODO get method name
    //void ConnectPlaceHolder(string id) //connect placeholder
    //{
    //    if(lastMessage == "OnlineGrab")
    //    {
    //        NodeLink NL = GameObject.Find(guid).GetComponent<NodeLink>();
    //        NL.Fire(lastMessage, tempguid);
    //    }

    //    tempViewPoint = id;
    //}

    //TODO get methood name
    void DisconnectPlaceHolder(string disconnectid) //disconnect placeholder
    {
    }
}
