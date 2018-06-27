using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class networkAvatars : MonoBehaviour {

    GameObject viewpoints;
    public GameObject avatar;
    int numberOfPlayers = 0;

    // Use this for initialization
    void Start()
    {
        viewpoints = transform.Find("Viewpoints").gameObject;
    }

    // Update is called once per frame
    void Update () {
        if (numberOfPlayers != viewpoints.transform.childCount)
        {
            Debug.Log("IIIINNNNN");
            numberOfPlayers = viewpoints.transform.childCount;
            var user = Instantiate(avatar);
            user.transform.parent = viewpoints.transform.GetChild(numberOfPlayers - 1);
            user.transform.localPosition = Vector3.zero;
        }
		
	}
}
