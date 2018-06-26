using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VertexUnityPlayer;

public class FindVERTXobj : MonoBehaviour {

    public GameObject sceneLink;
    public int numberOfImportedObjects;

    void Start()
    {
        sceneLink = gameObject;
        StartCoroutine(CountObjects());

        //Debug.Log(gameObject.GetComponent<NodeLink>());

    }

    IEnumerator CountObjects()
    {
        yield return new WaitForSeconds(5);
        numberOfImportedObjects = gameObject.transform.childCount - 2;
    }

    void AddRigidBody()
    {
       for(int i = 0; i < numberOfImportedObjects; i++)
        {
            var currentObject = sceneLink.transform.GetChild(i);
            currentObject.tag = "EditOnly";
        }
    }


}
