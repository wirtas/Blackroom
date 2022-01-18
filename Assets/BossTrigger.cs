using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    [SerializeField] private Enemy boss;
    [SerializeField] private GameObject plane;
    
    private void OnTriggerEnter(Collider hitInfo)
    {
        if (!hitInfo.CompareTag("Player")) return;
        boss.gameObject.SetActive(true);
        plane.gameObject.SetActive(false);
    }
}
