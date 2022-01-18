using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    [SerializeField] private GameObject winScreen;
    private void OnTriggerEnter(Collider hitInfo)
    {
        if (hitInfo.CompareTag("Player")) StartCoroutine(Win());
    }

    private IEnumerator Win()
    {
        winScreen.SetActive(true);
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("TitleScreen", LoadSceneMode.Single);
    }
}
