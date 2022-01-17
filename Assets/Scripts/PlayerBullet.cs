using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float bulletSpeed = 30f;

    public Enemy BombParent { get; private set; }
    private void Start()
    {
        rb.velocity = transform.forward * bulletSpeed;
    }

    private void OnTriggerEnter(Collider hitInfo)
    {
        if (hitInfo.CompareTag("Player") || hitInfo.CompareTag("Weapon")) return;

        rb.velocity = Vector3.zero;
        gameObject.transform.SetParent(hitInfo.transform);

        if (hitInfo.CompareTag("Enemy"))
        {
            BombParent = GetComponentInParent<Enemy>();
        }
    }
}