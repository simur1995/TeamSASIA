using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VertexUnityPlayer;

public class FindVERTXobj : MonoBehaviour {

    public GameObject currentImport;
    public int numberOfImportedObjects;

    void Start()
    {

        StartCoroutine(CountObjects());

        //Debug.Log(gameObject.GetComponent<NodeLink>());

    }

    IEnumerator CountObjects()
    {
        yield return new WaitForSeconds(5);
        numberOfImportedObjects = gameObject.transform.childCount - 2;

        for (int i = 0; i < numberOfImportedObjects; i++)
        {
            var currentObject = gameObject.transform.GetChild(i);
            Debug.Log(currentObject.name);
        }
    }

    void CreateGameObjects()
    {
       List<GameObject> importedObjectsList = new List<GameObject>();
       for(int i = 0; i < numberOfImportedObjects; i++)
       {
            importedObjectsList.Add(gameObject.transform.GetChild(i).gameObject);
            var currentObject = gameObject.transform.GetChild(i);
            Debug.Log(currentObject.name);
       }
    }



}
