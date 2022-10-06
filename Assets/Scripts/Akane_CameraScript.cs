using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Akane_CameraScript : MonoBehaviour
{
    public Transform Playerposition;
    private Vector3 cameraoffset;
    public Vector3 cameraPosition = new Vector3(5,7,0);
    public Quaternion cameraRotation = new Quaternion(55,-90, 0, 0);
    void Start()
    {
        cameraPosition = Playerposition.position + cameraPosition;
        transform.rotation = cameraRotation;
        //transform.rotation = cameraRotation;
    }
    void Update()
    {
        Vector3 newpos = Playerposition.position + cameraPosition;
        transform.position = newpos;
        
    }
}
