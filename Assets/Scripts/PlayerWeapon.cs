using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private PlayerBullet bulletPrefab;
    [SerializeField] private Transform fireOrigin;
    [SerializeField] private ParticleSystem boom;
    [SerializeField] private int maxBombs = 3;
    [SerializeField] private Material activeAmmo, emptyAmmo;
    [SerializeField] private GameObject[] ammo;
    
    private List<PlayerBullet> activeBombs = new List<PlayerBullet>();

    private void Update()
    {
        Shoot(); //LPM
        Boom();  //PPM
    }

    private void Shoot()
    {
        if (!Input.GetButtonDown("Fire1") || (activeBombs.Count >= maxBombs)) return;
        
        PlayerBullet clone = Instantiate(bulletPrefab, fireOrigin.position, fireOrigin.rotation);
        activeBombs.Add(clone);
        ChangeAmmo(activeBombs, false);
    }

    private void Boom()
    {
        if (!Input.GetButtonDown("Fire2") || (activeBombs.Count < 1) || activeBombs.Count <= 0) return;

        foreach (PlayerBullet b in activeBombs)
        {
            if (b == null)
            {
                continue;
            }

            Transform t = b.transform;
            Instantiate(boom, t.position, t.rotation);
            if (b.BombParent != null)
            {
                b.BombParent.GetHit();
            }
            Destroy(b.gameObject);
        }

        activeBombs.Clear();
        ChangeAmmo(activeBombs, true);
    }

    private void ChangeAmmo(List<PlayerBullet> l, bool clear)
    {
        if(clear)
        { 
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
