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
        fireData.viewpointid = temp[2];
        NL.Fire(temp[0], fireData);

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
        if(tempguid != fireInfo.guid && !heldGO.Contains(fireInfo))
        {
            heldGO.Add(fireInfo);
            Debug.Log("RECEIVED");
        }

    }

    void OnlineDrop(MetaData fireInfo)
    {
        if(tempguid != fireInfo.guid)
        {
            heldGO.Remove(fireInfo);
        }
        else
        {
            tempguid = null;
        }
    }

    void NodeLink_Loaded()
    {
        NL = GetComponent<NodeLink>();
        Debug.Log("Loaded");
        heldGO = ObjectMovement.heldGO;
 
        //GameObject.Find("Player").GetComponent<ObjectMovement>()
    }

    //TODO get method name
    void wtfisthiscalled() //connect placeholder
    {
        if(lastMessage == "OnlineGrab")
        {
            NL.Fire(lastMessage, tempguid);
        }
    }

    //TODO get methood name
    void wtfisthiscalled2(string disconnectid) //disconnect placeholder
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
}
