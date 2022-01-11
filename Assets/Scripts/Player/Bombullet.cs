using UnityEngine;

public class Bombullet : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed = 15f; // Bullet speed

    public Enemy bombParent;
    
    void Start()
    {
        rb.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider hitInfo)
    {
        Debug.Log(hitInfo.name);
        if (hitInfo.CompareTag("Player") || hitInfo.CompareTag("Weapon")) return;

        rb.velocity = Vector3.zero;
        gameObject.transform.SetParent(hitInfo.transform);

        if (hitInfo.CompareTag("Enemy"))
        {
            bombParent = GetComponentInParent<Enemy>();
        }
    }
}