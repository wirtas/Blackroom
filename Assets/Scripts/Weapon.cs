using System.Linq;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform fireOrigin;
    [SerializeField] private int maxBombs = 3; // Quantity of possible active bombs
    private short activeBombsCounter;
    private GameObject[] activeBombs = new GameObject[3];
    
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && (activeBombsCounter < maxBombs))
        {
            Shoot();
        }

        if (Input.GetButtonDown("Fire2") && (activeBombsCounter >= 1))
        {
            Boom();
        }
    }

    private void Shoot()
    {
        
        activeBombs[activeBombsCounter] = Instantiate(bulletPrefab, fireOrigin.position, fireOrigin.rotation);
        activeBombsCounter++;
        Debug.Log(activeBombsCounter.ToString());
    }

    private void Boom()
    {
        //TODO potezny wybuch lamiacy duze drzewa i kolyszacy trzcina
        

        if (activeBombsCounter <= 0) return;
        
        foreach (GameObject b in activeBombs)
        {
           Destroy(b);
        }

        activeBombsCounter = 0;

    }
}
