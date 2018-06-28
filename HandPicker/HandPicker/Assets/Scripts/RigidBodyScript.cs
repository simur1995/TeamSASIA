using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VertexUnityPlayer;

public class RigidBodyScript : MonoBehaviour
{
    public List<GameObject> vertxObjectList;
    public int numberOfObjects;

    void Start()
    {
        vertxObjectList = new List<GameObject>();
        StartCoroutine(RefreshObjectList());
    }

    void ScanObjects()
    {
        Debug.Log("Scanning objects");
        numberOfObjects = gameObject.transform.childCount - 2;
    }

    void PopulateObjectList()
    {
        Debug.Log("Populating list");
        vertxObjectList.Clear();
        numberOfObjects = 0;
        foreach (Transform child in transform)
        {
            Debug.Log(child.name);
            if (child.name != "Viewpoints" && child.name != "ViewPoint Follower")
            {
                numberOfObjects++;
                vertxObjectList.Add(child.gameObject);
            }
        }

    }

    void AddRigidComponent()
    {
        Debug.Log("Adding rigid components");
        foreach (GameObject model in vertxObjectList)
        {
            if(model.GetComponent<Rigidbody>() == null)
            {
                model.AddComponent<Rigidbody>();
            }

        }
    }

    IEnumerator RefreshObjectList()
    {
        int loop = 0;
        while (true)
        {
            loop++;
            Debug.Log("Refresh process(" + loop + ") started");
            ScanObjects();
            PopulateObjectList();
            AddRigidComponent();
            Debug.Log("Refresh process(" + loop + ") ended");
            yield return new WaitForSeconds(3);
        }
    }
}
