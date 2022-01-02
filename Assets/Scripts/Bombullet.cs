using System;
using UnityEngine;

public class Bombullet : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed = 15f; // Bullet speed
    [SerializeField] private ParticleSystem particleSystem;
    void Start()
    {
        rb.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider hitInfo)
    {
        Debug.Log(hitInfo.name);
        if (hitInfo.CompareTag("Player")) return;
        
        rb.velocity = Vector3.zero;
        gameObject.transform.SetParent(hitInfo.transform);

    }

    private void OnDestroy()
    {
        Instantiate(particleSystem, transform.position, transform.rotation);
        
    }
}
