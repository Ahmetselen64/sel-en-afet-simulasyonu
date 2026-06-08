using UnityEngine;
using TMPro;

public class FloodController : MonoBehaviour
{
    public float countdownTime = 60f;
    public float riseSpeed = 0.04f;
    public float maxWaterHeight = 1.5f;
    public TextMeshProUGUI timerText;

    void Update()
    {
        if (countdownTime > 0)
        {
            countdownTime -= Time.deltaTime;
            if (timerText != null)
            {
                timerText.text = "Sel Başlangıcı: " + Mathf.CeilToInt(countdownTime).ToString() + "s";
            }
        }
        else
        {
            if (timerText != null)
            {
                timerText.text = "DİKKAT: SEL BAŞLADI!";
            }
            
            if (transform.position.y < maxWaterHeight)
            {
                transform.Translate(Vector3.up * riseSpeed * Time.deltaTime, Space.World);
            }
        }
    }
}
