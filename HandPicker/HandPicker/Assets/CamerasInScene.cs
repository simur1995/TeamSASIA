using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamerasInScene : MonoBehaviour {
    public GameObject viewpoints;
    private int count;
    public Text numberofPlayers;

    
    // Use this for initialization
    void Start () {
        
        

    }
	
	// Update is called once per frame
	void Update () {
        count = viewpoints.transform.childCount;
        numberofPlayers.text = "Number of Players: " + count.ToString();        
    }
}
