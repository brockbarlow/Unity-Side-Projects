using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class movement : NetworkBehaviour {

    public float movementSpeed = 5f;
    public float turnSpeed = 45f;
    public float cameraDistance = 16f;
    public float cameraHeight = 16f;
    public Rigidbody rb;
    public Transform mainCamera;
    public Vector3 cameraOffSet;

    public void Start()
    {
        if (!isLocalPlayer)
        {
            Destroy(this);
            return;
        }

        rb = GetComponent<Rigidbody>();
        cameraOffSet = new Vector3(0f, cameraHeight, -cameraDistance);
        mainCamera = Camera.main.transform;
        MoveCamera();
    }

    public void FixedUpdate()
    {
        float turnAmount = Input.GetAxisRaw("Horizontal");
        float moveAmount = Input.GetAxisRaw("Vertical");

        Vector3 deltaTranslation = rb.position + transform.forward * movementSpeed * moveAmount * Time.deltaTime;
        rb.MovePosition(deltaTranslation);

        Quaternion deltaRotation = Quaternion.Euler(turnSpeed * new Vector3(0, turnAmount, 0) * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);

        MoveCamera();
    }

    public void MoveCamera()
    {
        mainCamera.position = transform.position;
        mainCamera.rotation = transform.rotation;
        mainCamera.Translate(cameraOffSet);
        mainCamera.LookAt(transform);
    }
}
