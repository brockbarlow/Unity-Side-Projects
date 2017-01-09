//script created by: Brock Barlow
//script created on: 1/9/2017
//purpose: move the player with wasd and move the camera with the mouse

using UnityEngine;

namespace Assets.Scripts
{
    public class Movement2 : MonoBehaviour
    {
        private float _movementSpeed = 10.0f; //how fast the player will move
        private float _turnSpeed = 105.0f; //how fast the player will turn
        private float _cameraDistance = 0.0f; //how far the camera is from the player
        private float _cameraHeight = 0.0f; //how high the camera is from the player
        public Rigidbody Rb;
        public Transform MainCamera;
        private Vector3 _cameraOffSet;

        public void Start()
        {
            Rb = GetComponent<Rigidbody>();
            _cameraOffSet = new Vector3(0.0f, _cameraHeight, -_cameraDistance);
            MainCamera = Camera.main.transform;
            MoveCamera();
        }

        public void FixedUpdate()
        {
            var turnAmountX = Input.GetAxis("Mouse X");
            //var turnAmountY = Input.GetAxis("Mouse Y");
            var moveAmount = Input.GetAxisRaw("Vertical");
            //var moveAmount = Input.GetAxisRaw("Horizontal");
            var deltaTranslation = Rb.position + transform.forward * _movementSpeed * moveAmount * Time.deltaTime;
            Rb.MovePosition(deltaTranslation);
            var deltaRotation = Quaternion.Euler(_turnSpeed * new Vector3(0, turnAmountX, 0) * Time.deltaTime);
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