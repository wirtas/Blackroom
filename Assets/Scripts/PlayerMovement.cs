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
    
    private Vector3 velocity;
    private bool isGrounded;
    private void Update()
    {
        Walk();
    }

    private void Walk()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //VELOCITY RESET
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        
        //MOVEMENT
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * (speed * Time.deltaTime));

        //GRAVITY & JUMPING
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed *= 2f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed /= 2f;
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);  
    }
}
