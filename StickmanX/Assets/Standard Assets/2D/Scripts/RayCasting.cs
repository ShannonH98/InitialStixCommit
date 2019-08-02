using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCasting : MonoBehaviour {

    public Transform sightStart, sightEnd;
	// Update is called once per frame
	void Update () {
        Raycasting();
        Behaviours();
	}

    void Raycasting()
    {
        Debug.DrawLine(sightStart.position, sightEnd.position, Color.red);
    }
    
    void Behaviours()
    {

    }
}
