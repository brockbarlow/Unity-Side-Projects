namespace Player
{
    using UnityEngine;

    public class CameraMovement : MonoBehaviour
    {
        public enum RotationAxes
        {
            MouseXAndY = 0, MouseX = 1, MouseY = 2
        }

        private Quaternion m_OriginalRotation;
        private float m_RotationX;
        private float m_RotationY;
        public Rigidbody rigidBody;
        public RotationAxes axes;
        public float sensitivityX = 15.0f;
        public float sensitivityY = 15.0f;
        public float minX = -10000.0f;
        public float maxX = 10000.0f;
        public float minY = -60.0f;
        public float maxY = 60.0f;

        public void Start()
        {
            if (!rigidBody) { return; }
            rigidBody.freezeRotation = true;
            m_OriginalRotation = transform.localRotation;
            m_RotationX = 0.0f;
            m_RotationY = 0.0f;
        }

        public void Update()
        {
            switch (axes)
            {
                case RotationAxes.MouseXAndY:
                    {
                        m_RotationX += Input.GetAxisRaw("Mouse X") * sensitivityX;
                        m_RotationY += Input.GetAxisRaw("Mouse Y") * sensitivityY;
                        m_RotationX = Mathf.Clamp(m_RotationX, minX, maxX);
                        m_RotationY = Mathf.Clamp(m_RotationY, minY, maxY);
                        var xQuaternion = Quaternion.AngleAxis(m_RotationX, Vector3.up);
                        var yQuaternion = Quaternion.AngleAxis(-m_RotationY, Vector3.right);
                        transform.localRotation = m_OriginalRotation * xQuaternion * yQuaternion;
                    }
                    break;
                case RotationAxes.MouseX:
                    {
                        m_RotationX += Input.GetAxisRaw("Mouse X") * sensitivityX;
                        m_RotationX = Mathf.Clamp(m_RotationX, minX, maxX);
                        var xQuaternion = Quaternion.AngleAxis(m_RotationX, Vector3.up);
                        transform.localRotation = m_OriginalRotation * xQuaternion;
                    }
                    break;
                case RotationAxes.MouseY:
                    {
                        m_RotationY += Input.GetAxisRaw("Mouse Y") * sensitivityY;
                        m_RotationY = Mathf.Clamp(m_RotationY, minY, maxY);
                        var yQuaternion = Quaternion.AngleAxis(-m_RotationY, Vector3.right);
                        transform.localRotation = m_OriginalRotation * yQuaternion;
                    }
                    break;
            }
        }
    }
}