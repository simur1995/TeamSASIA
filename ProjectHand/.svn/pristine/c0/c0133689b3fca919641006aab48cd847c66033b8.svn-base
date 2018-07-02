using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VertexUnityPlayer;


public class MessageManager : SingletonPattern<MessageManager>
{
    private string lastMessage;
    //NodeLink NL;
    public string Tempguid;
    public string userid;
    public Dictionary<string, string> NameAndID;
    //private string tempViewPoint;

    void Grabbed(string guid)
    {
        NodeLink NL = NodeLink.Find(guid);
        Tempguid = guid;
        NL.Fire("OnlineGrab", guid);
        lastMessage = "OnlineGrab";
        Debug.Log("SENT");
    }

    void Dropped(string guid)
    {
        NodeLink NL = NodeLink.Find(guid);
        lastMessage = "Dropped";
        NL.Fire("OnlineDrop", guid);   
    }

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

}
