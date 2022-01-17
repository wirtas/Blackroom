using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Material weapon;
    [SerializeField] private int initHp = 10;
    private static readonly int EmissionColor = Shader.PropertyToID("_EmissionColor");
    private int health = 10;
    
    public int Health
    {
        get => health;
        set
        {
            health = value;
            SetColor(value);
        }
    }
    private void Start()
    {
        Health = initHp;
    }
    
    public void GetHit(int damage = 1)
    {
        Health -= damage;
    }

    private void SetColor(int h)
    {
        if (h <= 0)
        {
            weapon.SetColor(EmissionColor, Color.black);
        }
        else if (h <= 0.3*initHp)
        {
            weapon.SetColor(EmissionColor, Color.red * 3);
        }
        else if (initHp > h)
        {
            weapon.SetColor(EmissionColor, Color.yellow * 3);
        }
        else
        {
            weapon.SetColor(EmissionColor, Color.green * 3);
        }
    }
}
