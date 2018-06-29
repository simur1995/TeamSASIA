using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeLinkGrabState : MonoBehaviour {

    void OnlineGrab(string guid)
    {
        if (MessageManager.Instance.Tempguid != guid && !ObjectMovement.heldGO.Contains(guid))
        {
            ObjectMovement.heldGO.Add(guid);
        }
        Debug.Log("RECEIVED");
        MessageManager.Instance.Tempguid = null;

    }

    void OnlineDrop(string guid)
    {
        if (guid != MessageManager.Instance.Tempguid)
        {
            ObjectMovement.heldGO.Remove(guid);
        }
    }

}
