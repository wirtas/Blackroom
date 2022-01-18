using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WallController : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemies;
    private int enemiesLeft;

    private void Start()
    {
        enemiesLeft = enemies.Count;
    }

    private void Update()
    {
        foreach (GameObject enemy in enemies.Where(enemy => enemy == null))
        {
            enemiesLeft--;
            enemies.Remove(enemy);
            break;
        }
        
        if (enemiesLeft.Equals(0)) gameObject.SetActive(false);
    }
}
