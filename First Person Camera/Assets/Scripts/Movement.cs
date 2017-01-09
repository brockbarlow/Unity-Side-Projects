//script created by: Brock Barlow
//date created: 1/9/2017
//purpose of script: move the player and while the player moves, move the camera. set the camera to emulate a first person view

using UnityEngine;

namespace Assets.Scripts
{
    public class Movement : MonoBehaviour
    {
        public float MovementSpeed = 5.0f; //how fast the player will move
        public float TurnSpeed = 45.0f; //how fast the player will turn
        public float CameraDistance = 0.0f; //how far the camera is from the player
        public float CameraHeight = 0.0f; //how high the camera is from the player
        public Rigidbody Rb;
        public Transform MainCamera;
        public Vector3 CameraOffSet;

        public void Start()
        {
            Rb = GetComponent<Rigidbody>();
            CameraOffSet = new Vector3(0.0f, CameraHeight, -CameraDistance);
            MainCamera = Camera.main.transform;
            MoveCamera();
        }

        public void FixedUpdate()
        {
            var turnAmount = Input.GetAxisRaw("Horizontal");
            var moveAmount = Input.GetAxisRaw("Vertical");
            var deltaTranslation = Rb.position + transform.forward*MovementSpeed*moveAmount*Time.deltaTime;
            Rb.MovePosition(deltaTranslation);
            var deltaRotation = Quaternion.Euler(TurnSpeed * new Vector3(0, turnAmount, 0) * Time.deltaTime);
            Rb.MoveRotation(Rb.rotation * deltaRotation);
            MoveCamera();
        }

        public void MoveCamera()
        {
            MainCamera.position = transform.position;
            MainCamera.rotation = transform.rotation;
            MainCamera.Translate(CameraOffSet);
            MainCamera.LookAt(transform);
        }
    }
}