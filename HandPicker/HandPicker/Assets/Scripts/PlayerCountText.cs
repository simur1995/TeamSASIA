using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VertexUnityPlayer;

public class PlayerCountText : MonoBehaviour {

    public int playerCount;
    private Text playerCountText;


	// Use this for initialization
	void Start () {

        Debug.Log("asaf  "+ NodeLink.CurrentNodes());
    }

    // Update is called once per frame
    void Update () {


        //Text textObject = gameObject.GetComponent<Text>(); 
        //textObject.text = "PLAYER COUNT: " + playerCount;


    }

    void CountObjects()
    {
        NodeLink.CurrentNodes();
    }
}
