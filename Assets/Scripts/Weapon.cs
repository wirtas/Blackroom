using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform fireOrigin;
    [SerializeField] private ParticleSystem boom;
    [SerializeField] private int maxBombs = 3; // Quantity of possible active bombs
    private List<GameObject> activeBombs = new List<GameObject>();
    
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
        GameObject bullet = Instantiate(bulletPrefab, fireOrigin.position, fireOrigin.rotation);
        activeBombs.Add(bullet);
        Debug.Log(activeBombs.Count.ToString());
    }

    private void Boom()
    {
        //potezny wybuch lamiacy duze drzewa i kolyszacy trzcina
        if (activeBombs.Count <= 0) return;
        
        foreach (GameObject b in activeBombs)
        {
            Instantiate(boom, b.transform.position, b.transform.rotation);
            Destroy(b);
        }
        activeBombs.Clear();
    }
}
