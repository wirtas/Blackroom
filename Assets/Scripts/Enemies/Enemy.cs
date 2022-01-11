using UnityEngine;

public class Enemy : MonoBehaviour
{
   
    private int health;
    public int Health
    {
        get => health;
        set
        {
            health = value;
            if (value <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    public int MaxHealth { get; set; }

    public string Title { get; set; }
}

