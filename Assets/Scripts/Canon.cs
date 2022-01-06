using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    [SerializeField] private EnemyBullet bulletPrefab;
    [SerializeField] private Transform fireOrigin;
    [SerializeField] private float shootDelayTime;
    [SerializeField] private float range = 10f;

    private Transform playerPosition;
    private Vector3 muzzle;
    private float timeElapsed = 0;
    private void Start()
    {
        Player player = FindObjectOfType<Player>();
        playerPosition = player.transform;
        muzzle = fireOrigin.position;
    }

    private void Update()
    {
        if (timeElapsed > shootDelayTime && IsPlayerInRange())
        {
            Shoot();
            timeElapsed = 0;
        }

        timeElapsed += Time.deltaTime;
    }

    private void Shoot()
    {
        Vector3 direction = (playerPosition.position - muzzle).normalized;
        Debug.DrawRay(muzzle, direction, Color.red, 1f);
        EnemyBullet bullet = Instantiate(bulletPrefab, muzzle, Quaternion.LookRotation(direction));
        bullet.Init(direction);
    }

    private bool IsPlayerInRange()
    {
        float distance = Vector3.Distance(muzzle, playerPosition.position);
        return distance <= range;
    }

}
