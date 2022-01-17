using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private string title;
    private int health;

    public int Health
    {
        get => health;
        private set
        {
            health = value;
            if (value <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    public int MaxHealth => maxHealth;

    public string Title => title;

    public void GetHit(int damage = 1)
    {
        Health -= damage;
    }

    private void Awake()
    {
        Health = MaxHealth;
    }
}

