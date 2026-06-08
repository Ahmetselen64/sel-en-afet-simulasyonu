using UnityEngine;

public class MoveHintText
{
    public static void Execute()
    {
        GameObject hintText = GameObject.Find("Canvas/HintText");
        GameObject mainMenuPanel = GameObject.Find("Canvas/MainMenuPanel");

        if (hintText != null && mainMenuPanel != null)
        {
            hintText.transform.SetParent(mainMenuPanel.transform, true);
            
            // Ensure it's still at the bottom center
            RectTransform rectTransform = hintText.GetComponent<RectTransform>();
            rectTransform.anchorMin = new Vector2(0.5f, 0.05f);
            rectTransform.anchorMax = new Vector2(0.5f, 0.05f);
            rectTransform.pivot = new Vector2(0.5f, 0.5f);
            rectTransform.anchoredPosition = Vector2.zero;
        }
        else
        {
            Debug.LogError("HintText or MainMenuPanel not found.");
        }
    }
}