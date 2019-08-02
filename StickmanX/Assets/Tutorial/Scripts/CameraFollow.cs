using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset = new Vector3(0,0,-10);

    private void FixedUpdate()
    {
        //New pos + offset
        Vector3 newPos = target.position + offset;
        //Smoothing
        Vector3 smoothPos = Vector3.Lerp(transform.position, newPos, smoothSpeed);
        //Apply pos
        transform.position = smoothPos;
    }
}
