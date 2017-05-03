//script created by: Brock Barlow
//date created: 1/9/2017
//purpose of script: move the player and while the player moves, move the camera. set the camera to emulate a first person view

namespace Player_One
{
    using UnityEngine;

    public class Movement : MonoBehaviour
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
            var turnAmount = Input.GetAxisRaw("Horizontal");
            var moveAmount = Input.GetAxisRaw("Vertical");

            var deltaTranslation = Rb.position + transform.forward * _movementSpeed * moveAmount * Time.deltaTime;
            Rb.MovePosition(deltaTranslation);

            var deltaRotation = Quaternion.Euler(_turnSpeed * new Vector3(0, turnAmount, 0) * Time.deltaTime);
            Rb.MoveRotation(Rb.rotation * deltaRotation);

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