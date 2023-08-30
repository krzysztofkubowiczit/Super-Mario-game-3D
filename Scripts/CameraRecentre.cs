using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraRecentre : MonoBehaviour
{
    //Skrypt pozwalaj¹cy na powrót kamry do bazowego stanu
    private CinemachineFreeLook camera;

    void Start()
    {
        camera = GetComponent<CinemachineFreeLook>();
    }

    
    void Update()
    {
        if(Input.GetAxis("CameraRecentre")==1)
        {
            camera.m_RecenterToTargetHeading.m_enabled = true;

        }
        else
        {
            camera.m_RecenterToTargetHeading.m_enabled = false;
        }
    }
}
