using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private Transform PlayerTransform;
    private Vector3 TempPos;

    void Start()
    {
        PlayerTransform = GameObject.FindWithTag("Player").transform;
    }


    void LateUpdate()
    {
        TempPos = transform.position;
        TempPos.x = PlayerTransform.position.x;
        TempPos.y = PlayerTransform.position.y;

        transform.position = TempPos;
    }
}
