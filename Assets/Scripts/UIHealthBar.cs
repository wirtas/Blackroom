using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tf;
    [SerializeField] private Slider sd;

    public TextMeshProUGUI Tf => tf;

    public Slider Sd
    {
        get
        {
            gameObject.SetActive(true);
            if (sd.value == 0)
            {
                gameObject.SetActive(false);
            }

            return sd;
        }
    }
}