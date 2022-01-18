using UnityEngine;


public class BossController : EnemyCanon
{
    [SerializeField] private GameObject winPlatform;
    private void OnDestroy()
    {
        winPlatform.SetActive(true);
    }
}
