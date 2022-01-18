using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private Button button;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        button.onClick.AddListener(NewGame);
    }

    private void NewGame()
    {
        SceneManager.LoadScene("Level_1", LoadSceneMode.Single);
    }
}
