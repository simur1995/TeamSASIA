using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VertexUnityPlayer;

public class MetaData
{
    public string guid;
    public string viewpointid;
}

public class MessageManager : MonoBehaviour {
    private string lastMessage;
    NodeLink NL;
    List<MetaData> heldGO;
    string tempguid;
    public string userid;
    public Dictionary<string, string> NameAndID;
    private string tempViewPoint;
    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {

    }

    //this method takes a string organised as method,guid,viewpointid then creates a type metadata using last two and used the first to call the correct method
    void LocalMessageManage(string message) 
    {
        string[] temp = message.Split(',');
        MetaData fireData = new MetaData();
        fireData.guid = temp[1];
        fireData.viewpointid = userid;
        NL.SendMessage(temp[0], fireData);

    }

    void Grabbed(MetaData fireInfo)
    {
        tempguid = fireInfo.guid;
        NL.Fire("OnlineGrab", fireInfo);
        lastMessage = "OnlineGrab";
        Debug.Log("SENT");
    }

    void Dropped(MetaData FireInfo)
    {
        lastMessage = "Dropped";
        NL.Fire("OnlineDrop", FireInfo);   
    }

    void OnlineGrab(MetaData fireInfo)
    {
        if(name != fireInfo.viewpointid && !heldGO.Contains(fireInfo))
        {
            heldGO.Add(fireInfo);
            Debug.Log("RECEIVED");
        }

    }

    void OnlineDrop(MetaData fireInfo)
    {
        if(fireInfo.viewpointid != name)
        {
            heldGO.Remove(fireInfo);
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
        foreach (MetaData item in heldGO)
        {
            if(item.viewpointid == disconnectid)
            {
                heldGO.Remove(item);
                break;
            }
        }
    }

    MetaData finduser(string username)
    {
        foreach (MetaData item in heldGO)
        {
            if(item.viewpointid == username)
            {
                return item;
            }
        }
        Debug.Log("user does not exist");
        return null;
    }
}
