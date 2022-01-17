using UnityEngine;

public class EnemyBullet : MonoBehaviour
{ 
    [SerializeField] private Rigidbody rb; 
    [SerializeField] private float speed = 15f; // Bullet speed
    [SerializeField] private float activeTime = 20f;
    [SerializeField] private int damage = 1;
    
    private Vector3 direction;
    private float timeElapsed;

    public void Init(Vector3 dir)
    {
        this.direction = dir;
    }
    private void Start()
    {
        rb.velocity = direction * speed;
    }
    private void OnTriggerEnter(Collider hitInfo)
    {
        if (hitInfo.CompareTag("Player")) 
        {
            Player player = hitInfo.transform.GetComponent<Player>();
            player.GetHit(damage);
        }
        else if (hitInfo.CompareTag("Enemy"))
        {
            return;
        }
        Destroy(gameObject);
    }

    private void Update()
    {
        if (timeElapsed > activeTime)
        {
            Destroy(gameObject);
        }

        timeElapsed += Time.deltaTime;
    }
}
