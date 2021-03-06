﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VertexUnityPlayer;

public class CamerasInScene : MonoBehaviour {
    public GameObject viewpoints;
    public GameObject sceneLink;
    private int countPlayers;
    private int countObjects;
    public Text numberofPlayers;
    public Text numberofObjects;

    
    // Use this for initialization
    void Start () {
        
        

    }
	
	// Update is called once per frame
	void Update () {
        foreach (Renderer r in viewpoints.transform.GetComponentsInChildren<Renderer>())
        {
            if (r.enabled == true)
               countPlayers++;
        }
        countPlayers = countPlayers/2;
        countPlayers++;
        //countPlayers = viewpoints.transform.childCount;
       // countPlayers = viewpoints.transform.GetComponentsInChildren<Renderer>()..Length;
        numberofPlayers.text = "Number of Players: " + countPlayers.ToString();
        // countObjects = sceneLink.transform.childCount - countPlayers;
        countObjects = sceneLink.GetComponentsInChildren<NodeLink>().Length ;
        numberofObjects.text = "Number of Objects: " + countObjects.ToString();
        
    }
   
}
