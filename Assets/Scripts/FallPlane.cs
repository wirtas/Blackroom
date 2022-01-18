using UnityEngine;

public class FallPlane : MonoBehaviour
{
    private void OnTriggerEnter(Collider hitInfo)
    {
        if (!hitInfo.CompareTag("Player")) return;
        Player.Lose();
    }
}
