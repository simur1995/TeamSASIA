using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeOut : MonoBehaviour {

   
    List<Transform> playerCoords;
    List<Transform> currentPlayerCoords;

	// Use this for initialization
	void Start () {
        playerCoords = new List<Transform>();
        currentPlayerCoords = new List<Transform>();
        StartCoroutine(TimeOutRoutine());

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void findUsers(List<Transform> coords)
    {
        for (int i =0; i < transform.childCount ; i++)
        {
            if (transform.GetChild(i) != null)
            {
                    coords.Add(transform.GetChild(i).transform);
                    //wait 2m
                    Debug.Log("Getting coords of: " + coords.ToString());
                    //destroy
            }
        }
        
        
    }

    IEnumerator TimeOutRoutine()
    {
        int loop = 0;
        while (true)
        {
            loop++;
            findUsers(playerCoords);

            
            yield return new WaitForSeconds(5);

            findUsers(currentPlayerCoords);

            CheckCoords();

            Debug.Log("Loop: " + loop);
        }
        
    }

    void CheckCoords()
    {
        Debug.Log("CHECKED");

        for (int i = 0; i < playerCoords.Count; i++)
        {
            if (playerCoords[i].position == currentPlayerCoords[i].position)
            {
                Debug.Log("user is same");

            }
            else
            {
                Debug.Log("user is different");
            }
        }

        playerCoords.Clear();
        currentPlayerCoords.Clear();
    }
}
