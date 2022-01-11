using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Bombullet bulletPrefab;
    [SerializeField] private Transform fireOrigin;
    [SerializeField] private ParticleSystem boom;
    [SerializeField] private int maxBombs = 3; // Quantity of possible active bombs
    private List<Bombullet> activeBombs = new List<Bombullet>();
    
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && (activeBombs.Count < maxBombs))
        {
            Shoot();
        }

        if (Input.GetButtonDown("Fire2") && (activeBombs.Count >= 1))
        {
            Boom();
        }
    }

    private void Shoot()
    {
        Bombullet clone = Instantiate(bulletPrefab, fireOrigin.position, fireOrigin.rotation);
        activeBombs.Add(clone);
    }

    private void Boom()
    {
        //potezny wybuch lamiacy duze drzewa i kolyszacy trzcina
        if (activeBombs.Count <= 0) return;
        
        foreach (Bombullet b in activeBombs)
        {
            if (b == null) continue;
            Instantiate(boom, b.transform.position, b.transform.rotation);
            if (b.bombParent != null) b.bombParent.Health -= 1;
            Destroy(b.gameObject);
        }
        activeBombs.Clear();
    }
    
}
