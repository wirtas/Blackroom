using UnityEngine;

public class LaserTrap : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 5;
    private float timeElapsed;
    private void Update()
    {
        if (0.01f < timeElapsed)
        {
            gameObject.transform.Rotate(0, rotationSpeed,0);
            timeElapsed = 0;
        }
        timeElapsed += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider hitInfo)
    {
        Debug.Log($"Enemy{hitInfo.name}");
        if (hitInfo.CompareTag("Player"))
        {
            Player player = hitInfo.transform.GetComponent<Player>();
            player.Health -= 1;
        }
    }
}
