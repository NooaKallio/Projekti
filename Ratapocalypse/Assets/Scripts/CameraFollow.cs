using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;  // Cameran kohde
    public float smoothSpeed = 0.125f;  // Cameran liikkuvuus
    public Vector3 offset;  // Etäisyys pelaajasta

    void LateUpdate()
    {
       
        Vector3 desiredPosition = target.position + offset;

    
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        Debug.Log("Camera position: " + transform.position);
        Debug.Log("Desired position: " + desiredPosition);        
    }
}
