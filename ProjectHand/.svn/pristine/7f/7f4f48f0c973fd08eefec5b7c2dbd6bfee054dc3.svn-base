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
        numberOfObjects = gameObject.transform.childCount - 2;
    }

    void PopulateObjectList()
    {
        vertxObjectList.Clear();
        foreach (Transform child in transform)
        {
            if (child.name != "Viewpoints" && child.name != "ViewPoint Follower")
            {
                vertxObjectList.Add(child.gameObject);
            }
        }

    }

    void AddRigidComponent()
    {
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
            ScanObjects();
            PopulateObjectList();
            AddRigidComponent();
            yield return new WaitForSeconds(3);
        }
    }
}
