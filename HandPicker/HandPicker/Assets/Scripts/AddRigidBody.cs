using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRigidBody : MonoBehaviour {

    public Rigidbody rb;
    public List<GameObject> vertxObjectList;
    public int numberOfObjects;

	// Use this for initialization
	void Start () {
        vertxObjectList = new List<GameObject>();

        StartCoroutine(RefreshObjectList());
	}
	
	// Update is called once per frame
	void Update () {

        ScanObjects();

    }

    void ScanObjects()
    {
        numberOfObjects = gameObject.transform.childCount - 2;
    }


    IEnumerator RefreshObjectList()
    {

        yield return new WaitForSeconds(5);

        for (int i = 0; i < numberOfObjects; i++)
        {
            vertxObjectList.Add(gameObject.transform.GetChild(i).gameObject);
        }

        AddRigidComponent();

    }

    void AddRigidComponent()
    {
        foreach(GameObject model in vertxObjectList)
        {
            model.AddComponent<Rigidbody>();
        }
    }
}
