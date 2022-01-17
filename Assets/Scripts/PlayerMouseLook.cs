using UnityEngine;

public class PlayerMouseLook : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 100f;
    [SerializeField] private Transform playerBody;
    [SerializeField] private UIHealthBar healthBar;
    [SerializeField] private float range = 10000f;
    
    private Enemy target;
    private float xRotation;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    private void Update()
    {
        MouseLook();
        EyeCast();
    }

    private void MouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    private void EyeCast()
    {
        if (!Physics.Raycast(transform.position, transform.forward, out RaycastHit eyesightHit, range)) return;
        Debug.Log(eyesightHit.collider.ToString());
        if (eyesightHit.collider.CompareTag("Enemy"))
        {
            target = eyesightHit.collider.GetComponentInParent<Enemy>();
            healthBar.Sd.value = target.Health;
            healthBar.Sd.maxValue = target.MaxHealth;
            healthBar.Tf.text = target.Title;
        }
        else if (target == null)
        {
            healthBar.Sd.value = 0;
        }
    }
}