//script created by: Brock Barlow
//script created on: 5/3/2017
//purpose: move player with wasd keys.

namespace Player_Three
{
    using UnityEngine;

    public class PlayerMovement : MonoBehaviour
    {
        private float _movementSpeed = 10.0f; 

        public Rigidbody Rb;

        public void Start()
        {
            Rb = GetComponent<Rigidbody>();
        }

        public void FixedUpdate()
        {
            var moveAmountForward = Input.GetAxisRaw("Vertical");
            var moveAmountRight = Input.GetAxisRaw("Horizontal");

            var deltaTranslationForward = Rb.position + transform.forward * _movementSpeed * moveAmountForward * Time.deltaTime;
            Rb.MovePosition(deltaTranslationForward);

            var deltaTranslationRight = Rb.position + transform.right * _movementSpeed * moveAmountRight * Time.deltaTime;
            Rb.MovePosition(deltaTranslationRight);
        }
    }
}