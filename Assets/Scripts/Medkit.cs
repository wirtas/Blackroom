using UnityEngine;

public class Medkit : MonoBehaviour
{
    private void OnTriggerEnter(Collider hitInfo)
    {
        if (!hitInfo.CompareTag("Player")) return;
        Player player = hitInfo.transform.GetComponent<Player>();
        player.Heal();
        Destroy(gameObject);
    }
}
