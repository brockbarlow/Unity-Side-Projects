//script created by: Brock Barlow
//script created on: 5/3/2017
//purpose: move camera with mouse input.

namespace Player_Three
{
    using UnityEngine;

    public class CameraMovement : MonoBehaviour
    {
        private Quaternion originalRotation;

        public Rigidbody rb;

        public enum RotationAxes
        {
            MouseXAndY = 0,
            MouseX = 1,
            MouseY = 2
        }

        public RotationAxes axes = RotationAxes.MouseXAndY;

        public float sensitivityX = 15f;
        public float sensitivityY = 15f;

        public float minX = -18000;
        public float maxX = 18000;

        public float minY = -60f;
        public float maxY = 60f;

        public float rotationX = 0f;
        public float rotationY = 0f;

        public void Start()
        {
            if (rb)
            {
                rb.freezeRotation = true;
                originalRotation = transform.localRotation;
            }
        }

        public void Update()
        {
            if (axes == RotationAxes.MouseXAndY)
            {
                rotationX += Input.GetAxisRaw("Mouse X") * sensitivityX;

                rotationY += Input.GetAxisRaw("Mouse Y") * sensitivityY;

                rotationX = Mathf.Clamp(rotationX, minX, maxX);

                rotationY = Mathf.Clamp(rotationY, minY, maxY);

                Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);

                Quaternion yQuaternion = Quaternion.AngleAxis(-rotationY, Vector3.right);

                transform.localRotation = originalRotation * xQuaternion * yQuaternion;
            }
            else if (axes == RotationAxes.MouseX)
            {
                rotationX += Input.GetAxisRaw("Mouse X") * sensitivityX;

                rotationX = Mathf.Clamp(rotationX, minX, maxX);

                Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);

                transform.localRotation = originalRotation * xQuaternion;
            }
            else
            {
                rotationY += Input.GetAxisRaw("Mouse Y") * sensitivityY;

                rotationY = Mathf.Clamp(rotationY, minY, maxY);

                Quaternion yQuaternion = Quaternion.AngleAxis(-rotationY, Vector3.right);

                transform.localRotation = originalRotation * yQuaternion;
            }
        }
    }
}