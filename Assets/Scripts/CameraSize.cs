using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSize : MonoBehaviour
{

    [SerializeField] private float horizontalResolution = 1080;
    [SerializeField] private CinemachineVirtualCamera _cam;

    void Start()
    {
        float currentAspect = (float)Screen.width / (float)Screen.height;
        _cam.m_Lens.OrthographicSize = horizontalResolution / currentAspect / 650;
    }


}
