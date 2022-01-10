using System;
using System.Security.Cryptography;
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
    void Start()
    {
        rb.velocity = direction * speed;
    }
    private void OnTriggerEnter(Collider hitInfo)
    {
        Debug.Log($"Enemy{hitInfo.name}");
        if (hitInfo.CompareTag("Enemy")) return;

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
