using UnityEngine;

public class EnemyBullet : MonoBehaviour
{ 
    [SerializeField] private Rigidbody rb; 
    [SerializeField] private float speed = 15f; // Bullet speed
    [SerializeField] private float activeTime = 20f;

    private Vector3 direction;
    private float timeElapsed;

    public void Init(Vector3 direction)
    {
        this.direction = direction;
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
            player.Health -= 1;
        }
        else if (hitInfo.CompareTag("Enemy")){
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
