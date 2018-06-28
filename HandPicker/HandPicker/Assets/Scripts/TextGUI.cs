using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VertexUnityPlayer;

public class TextGUI : MonoBehaviour
{
    GameObject SceneViewpoints;

    public List<GameObject> objectList;
    public List<GameObject> playerList;

    public int numberOfPlayers;
    public int numberOfObjects;

    // Use this for initialization
    void Start()
    {

        objectList = new List<GameObject>();
        playerList = new List<GameObject>();
        

        StartCoroutine(Scan());
        StartCoroutine(UpdateText());

    }

    void GetViewpointObject()
    {
        foreach (Transform child in transform)
        {
            if (child.name == "Viewpoints")
            {
                SceneViewpoints = child.gameObject;
                break;
            }
        }
    }

    void PopulatePlayerList()
    {
        playerList.Clear();
        foreach (Transform child in SceneViewpoints.transform)
        {
            playerList.Add(child.gameObject);
        }
    }

    void PopulateObjectList()
    {
        objectList.Clear();
        foreach (Transform child in transform)
        {
            if (child.name != "Viewpoints" && child.name != "ViewPoint Follower")
            {
                objectList.Add(child.gameObject);
            }
        }
    }

    IEnumerator Scan()
    {
        int count = 0;
        while (true)
        {
            count++;
            Debug.Log("Scanning" + " " + count);
            numberOfPlayers = SceneViewpoints.transform.childCount;
            numberOfObjects = transform.childCount - 2;
            yield return new WaitForSeconds(1);
        }
    }

    IEnumerator UpdateText()
    {
        int count = 0;
        while (true)
        {
            count++;
            Debug.Log("Updating Test" + " " + count);
            GetViewpointObject();
            PopulatePlayerList();
            yield return new WaitForSeconds(1);
        }
    }
}


