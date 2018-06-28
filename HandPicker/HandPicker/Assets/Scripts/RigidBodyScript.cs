using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VertexUnityPlayer;

public class RigidBodyScript : MonoBehaviour
{
    public List<GameObject> vertxObjectList;
    public int numberOfObjects;

    // Use this for initialization
    void Start()
    {
        vertxObjectList = new List<GameObject>();
        StartCoroutine(RefreshObjectList());
    }

    // Update is called once per frame
    void Update()
    {

        ScanObjects();

    }

    void ScanObjects()
    {
        numberOfObjects = gameObject.transform.childCount - 2;
        StartCoroutine(RefreshObjectList());
    }


    IEnumerator RefreshObjectList()
    {
        while (true)
        {
            PopulateObjectList();

            yield return new WaitForSeconds(5);
        }
    }

    void AddRigidComponent()
    {
        foreach (GameObject model in vertxObjectList)
        {
            model.AddComponent<Rigidbody>();
        }
    }

    void PopulateObjectList()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            vertxObjectList.Add(gameObject.transform.GetChild(i).gameObject);
        }

        //if(VertexUnityPlayer.)
        //{

        //}
    }


}
