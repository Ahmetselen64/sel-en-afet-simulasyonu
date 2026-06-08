using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CreateHintText
{
    public static void Execute()
    {
        GameObject canvas = GameObject.Find("Canvas");
        if (canvas == null)
        {
            Debug.LogError("Canvas not found");
            return;
        }

        GameObject hintTextObj = new GameObject("HintText");
        hintTextObj.transform.SetParent(canvas.transform, false);

        TextMeshProUGUI textComponent = hintTextObj.AddComponent<TextMeshProUGUI>();
        textComponent.text = "İpucu: Çevrenizdeki eşyalarla etkileşime geçmek için 'E' tuşuna basın.";
        textComponent.fontSize = 24;
        textComponent.alignment = TextAlignmentOptions.Center;
        textComponent.color = Color.white;

        RectTransform rectTransform = hintTextObj.GetComponent<RectTransform>();
        rectTransform.anchorMin = new Vector2(0.5f, 0.05f);
        rectTransform.anchorMax = new Vector2(0.5f, 0.05f);
        rectTransform.pivot = new Vector2(0.5f, 0.5f);
        rectTransform.anchoredPosition = Vector2.zero;
        rectTransform.sizeDelta = new Vector2(800, 50);
    }
}