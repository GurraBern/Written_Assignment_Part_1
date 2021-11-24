using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform cameraPiviot;
    public Vector3 camPosition;
    public Vector3 camRotation;
    public float offset;

    void Update()
    {
        transform.position = new Vector3(cameraPiviot.position.x, camPosition.y, cameraPiviot.position.z + offset);
        //transform.eulerAngles = new Vector3(camRotation.x, cameraPiviot.eulerAngles.y, camRotation.z);
    }
}
