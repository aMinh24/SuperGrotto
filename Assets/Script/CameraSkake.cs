using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraSkake : MonoBehaviour
{
    public CinemachineCollisionImpulseSource cinemachineImpulseSource;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            cinemachineImpulseSource.GenerateImpulse(Camera.main.transform.forward);
        }    
    }
}
