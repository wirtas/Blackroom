using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform groundCheck;
    [SerializeField] private CharacterController controller;
    [SerializeField] private LayerMask groundMask;

    [SerializeField] private float jumpHeight = 3f;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float gravity = -15f;
    [SerializeField] private float groundDistance = 0.4f;
    
    private Vector3 _velocity;
    private bool _isGrounded;
    void Update()
    {
        _isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // VELOCITY ON GROUND RESET
        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }
        
        //BASIC MOVEMENT
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * (speed * Time.deltaTime));

        //GRAVITY & JUMPING
        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        
        _velocity.y += gravity * Time.deltaTime;
        controller.Move(_velocity * Time.deltaTime);  
    }
}
