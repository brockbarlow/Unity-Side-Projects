//script created by: Brock Barlow
//script created on: 1/9/2017
//purpose: move the player with wasd and move the camera with the mouse

namespace Player_Two
{
    using UnityEngine;

    public class Movement2 : MonoBehaviour
    {
        private Transform MainCamera;
        private Vector3 _cameraOffSet;

        private float _movementSpeed = 10.0f; //how fast the player will move
        private float _turnSpeed = 105.0f; //how fast the player will turn
        private float _cameraDistance = 0.0f; //how far the camera is from the player
        private float _cameraHeight = 0.0f; //how high the camera is from the player

        public Rigidbody Rb;        

        public void Start()
        {
            Rb = GetComponent<Rigidbody>();
            _cameraOffSet = new Vector3(0.0f, _cameraHeight, -_cameraDistance);
            MainCamera = Camera.main.transform;
            MoveCamera();
        }

        public void FixedUpdate()
        {
            var turnAmountRight = Input.GetAxis("Mouse X");
            var turnAmountUp = Input.GetAxis("Mouse Y");
            var moveAmountVert = Input.GetAxisRaw("Vertical");
            var moveAmountHori = Input.GetAxisRaw("Horizontal");

            var deltaTranslationForward = Rb.position + transform.forward * _movementSpeed * moveAmountVert * Time.deltaTime;
            Rb.MovePosition(deltaTranslationForward);

            var deltaTranslationRight = Rb.position + transform.right * _movementSpeed * moveAmountHori * Time.deltaTime;
            Rb.MovePosition(deltaTranslationRight);

            var deltaRotationRight = Quaternion.Euler(_turnSpeed * new Vector3(0, turnAmountRight, 0) * Time.deltaTime);
            Rb.MoveRotation(Rb.rotation * deltaRotationRight);

            var deltaRotationUp = Quaternion.Euler(_turnSpeed * new Vector3(-turnAmountUp, 0, 0) * Time.deltaTime);
            Rb.MoveRotation(Rb.rotation * deltaRotationUp);

            MoveCamera();
        }

        public void MoveCamera()
        {
            MainCamera.position = transform.position;
            MainCamera.rotation = transform.rotation;
            MainCamera.Translate(_cameraOffSet);
            MainCamera.LookAt(transform);
        }
    }
}