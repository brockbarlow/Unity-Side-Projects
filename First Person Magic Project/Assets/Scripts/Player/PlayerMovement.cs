namespace Player
{
    using UnityEngine;

    public class PlayerMovement : MonoBehaviour
    {
        private float m_MovementSpeed;
        public Rigidbody rigidBody;

        public void Start()
        {
            rigidBody = GetComponent<Rigidbody>();
            m_MovementSpeed = 10.0f;
        }

        public void FixedUpdate()
        {
            var moveAmountForward = Input.GetAxisRaw("Vertical");
            var moveAmountRight = Input.GetAxisRaw("Horizontal");
            var deltaTranslationForward = rigidBody.position + transform.forward * m_MovementSpeed * moveAmountForward * Time.deltaTime;
            rigidBody.MovePosition(deltaTranslationForward);
            var deltaTranslationRight = rigidBody.position + transform.right * m_MovementSpeed * moveAmountRight * Time.deltaTime;
            rigidBody.MovePosition(deltaTranslationRight);
        }
    }
}