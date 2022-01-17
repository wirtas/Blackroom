using UnityEngine;

public class EnemyLaserTrap : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 5;
    [SerializeField] private int damage = 1;
    private float timeElapsed;
    private void Update()
    {
       Rotate();
    }

    private void OnTriggerEnter(Collider hitInfo)
    {
        Debug.Log($"Enemy{hitInfo.name}");
        if (hitInfo.CompareTag("Player"))
        {
            hitInfo.GetComponent<Player>().GetHit(damage);
        }
    }

    private void Rotate()
    {
        if (0.01f < timeElapsed)
        {
            gameObject.transform.Rotate(0, rotationSpeed,0);
            timeElapsed = 0;
        }
        timeElapsed += Time.deltaTime;
    }
}
