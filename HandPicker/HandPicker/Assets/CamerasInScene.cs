using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        countPlayers = viewpoints.transform.childCount;
        numberofPlayers.text = "Number of Players: " + countPlayers.ToString();
        countObjects = sceneLink.transform.childCount - countPlayers;
        numberofObjects.text = "Number of Objects: " + countObjects.ToString();
    }
}
