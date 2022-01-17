using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Bombullet bulletPrefab;
    [SerializeField] private Transform fireOrigin;
    [SerializeField] private ParticleSystem boom;
    [SerializeField] private int maxBombs = 3;
    [SerializeField] private Material activeAmmo, emptyAmmo;
    [SerializeField] private GameObject[] ammo;
    
    private List<Bombullet> activeBombs = new List<Bombullet>();

    private void Update()
    { 
        Shoot(); //LPM
        Boom();  //PPM
    }

    private void Shoot()
    {
        if (!Input.GetButtonDown("Fire1") || (activeBombs.Count >= maxBombs)) return;
        
        Bombullet clone = Instantiate(bulletPrefab, fireOrigin.position, fireOrigin.rotation);
        activeBombs.Add(clone);
        ChangeAmmo(activeBombs, false);
    }

    private void Boom()
    {
        if (!Input.GetButtonDown("Fire2") || (activeBombs.Count < 1) || activeBombs.Count <= 0) return;

        foreach (Bombullet b in activeBombs)
        {
            if (b == null) continue;
            Instantiate(boom, b.transform.position, b.transform.rotation);
            if (b.bombParent != null) b.bombParent.Health -= 1;
            Destroy(b.gameObject);
        }

        activeBombs.Clear();
        ChangeAmmo(activeBombs, true);
    }

    private void ChangeAmmo(List<Bombullet> l, bool clear)
    {
        if(clear){ 
            foreach (GameObject am in ammo) 
            { 
                MeshRenderer mesh = am.GetComponent<MeshRenderer>();
                mesh.material = activeAmmo; 
            }
        }
        else
        {
            MeshRenderer mesh = ammo[l.Count-1].GetComponent<MeshRenderer>();
            mesh.material = emptyAmmo;
        }
    }
}
