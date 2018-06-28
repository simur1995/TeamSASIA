using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeOut : MonoBehaviour {

   
    List<Vector3> playerCoords;
    List<Vector3> currentPlayerCoords;

	// Use this for initialization
	void Start () {
        playerCoords = new List<Vector3>();
        currentPlayerCoords = new List<Vector3>();
        StartCoroutine(TimeOutRoutine());

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void findUsers(List<Vector3> coords)
    {
        for (int i =0; i < transform.childCount ; i++)
        {
            if (transform.GetChild(i) != null)
            {
                    coords.Add(transform.GetChild(i).transform.position);
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

            yield return new WaitForSeconds(2);

            findUsers(currentPlayerCoords);

            yield return new WaitForSeconds(2);

            CheckCoords();

            Debug.Log("Loop: " + loop);
        }
        
    }

    void CheckCoords()
    {
        Debug.Log("CHECKED");

        for (int i = 0; i < playerCoords.Count; i++)
        {
            if (playerCoords[i] == currentPlayerCoords[i])
            {
                Debug.Log("user is same");

            }
            else
            {
                Debug.Log("user is different");
            }
            //playerCoords.Remove(playerCoords[i]);
            //currentPlayerCoords.Remove(currentPlayerCoords[i]);
        }

        playerCoords.Clear();
        currentPlayerCoords.Clear();
    }
}
