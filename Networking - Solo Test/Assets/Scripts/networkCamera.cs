﻿using UnityEngine;
using UnityEngine.Networking;

public class networkCamera : NetworkManager {

    public Transform sceneCamera;
    public float cameraRotationRadius = 24f;
    public float cameraRotationSpeed = 3f;
    public bool canRotate = true;
    public float rotation;

    public override void OnStartClient(NetworkClient client)
    {
        canRotate = false;
    }

    public override void OnStartHost()
    {
        canRotate = false;
    }

    public override void OnStopClient()
    {
        canRotate = true;
    }

    public override void OnStopHost()
    {
        canRotate = true;
    }

    public void Update()
    {
        if (!canRotate)
        {
            return;
        }

        rotation += cameraRotationSpeed * Time.deltaTime;

        if (rotation >= 360f)
        {
            rotation -= 360f;
        }

        sceneCamera.position = Vector3.zero;
        sceneCamera.rotation = Quaternion.Euler(0f, rotation, 0f);
        sceneCamera.Translate(0f, cameraRotationRadius, -cameraRotationRadius);
        sceneCamera.LookAt(Vector3.zero);
    }
}
