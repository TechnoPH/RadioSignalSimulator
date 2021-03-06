﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public  float Y_ANGLE_MIN = 10.0f;
    public  float Y_ANGLE_MAX = 90.0f;

    public Transform lookAt;
    public Transform camTransform;
    private Camera cam;

    public float distance = 60.0f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    public float sensitivityX = 4.0f;
    public float sensitivityY = 1.0f;

    private void Start()
    {
        camTransform = transform;
        cam = Camera.main;

    }

    private void Update()
    {
        currentX += Input.GetAxis("Mouse X");
        currentY += Input.GetAxis("Mouse Y");

        currentY = Mathf.Clamp(currentX, Y_ANGLE_MIN, Y_ANGLE_MAX);
    }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        camTransform.position = lookAt.position + rotation * dir;
        camTransform.LookAt(lookAt.position);
    }
}
