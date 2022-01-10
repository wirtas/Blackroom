using UnityEngine;

public class LaserTrap : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 5;
    private float timeElapsed;
    void Update()
    {
        if (0.01f < timeElapsed)
        {
            gameObject.transform.Rotate(0, rotationSpeed,0);
            timeElapsed = 0;
        }
        timeElapsed += Time.deltaTime;
    }
}
