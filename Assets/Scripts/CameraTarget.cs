using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{

    private float _currenPosY;
    void Update()
    {
        transform.localPosition = new Vector3(0f, transform.localPosition.y, transform.localPosition.z);
    }
}
