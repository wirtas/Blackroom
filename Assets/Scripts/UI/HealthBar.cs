using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float range = 10000f;
    [SerializeField] private Slider sd;
    [SerializeField] private TextMeshProUGUI tF;
    [SerializeField] private float fadeTime = 3f;

    private float timeElapsed;
    private Enemy target;
    private void Start()
    {
        Curtain(false);
    }

    private void Update()
    {
        if (!Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit eyesightHit, range)) return;
        
        Debug.Log(eyesightHit.collider.ToString());
        if (eyesightHit.collider.CompareTag("Enemy"))
        {
            Curtain(true);
            target = eyesightHit.collider.GetComponentInParent<Enemy>();
            sd.value = target.Health;
            sd.maxValue = target.MaxHealth;
            tF.text = target.Title;
                
            timeElapsed = 0f;

        }
        else if (timeElapsed > fadeTime) Curtain(false);
        else timeElapsed += Time.deltaTime;
        if (target == null) sd.value = 0;
    }

    private void Curtain(bool s)
    {
        sd.transform.GetChild(0).gameObject.SetActive(s);
        sd.transform.GetChild(1).gameObject.SetActive(s);
        tF.gameObject.SetActive(s);
    }
}