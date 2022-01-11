using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int health = 10;

    public int Health
    {
        get => health;
        set
        {
            health = value;
            if (value <= 0)
            {
              //  Destroy(gameObject);
            }
        }
    }
}
