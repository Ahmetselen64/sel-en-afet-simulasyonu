using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;

public class ImproveLeaderboardVisuals
{
    public static void Execute()
    {
        Canvas canvas = Object.FindFirstObjectByType<Canvas>();
        if (canvas == null)
        {
            Debug.LogError("Canvas not found!");
            return;
        }

        // 1. Create BackgroundImage
        GameObject bgObj = new GameObject("BackgroundImage");
        bgObj.transform.SetParent(canvas.transform, false);
        bgObj.transform.SetSiblingIndex(0); // First child

        Image bgImage = bgObj.AddComponent<Image>();
        Color bgColor;
        if (ColorUtility.TryParseHtmlString("#1A2530", out bgColor))
        {
            bgImage.color = bgColor;
        }

        RectTransform bgRect = bgObj.GetComponent<RectTransform>();
        bgRect.anchorMin = Vector2.zero;
        bgRect.anchorMax = Vector2.one;
        bgRect.offsetMin = Vector2.zero;
        bgRect.offsetMax = Vector2.zero;

        // 2 & 3. Create TitleText
        GameObject titleObj = new GameObject("TitleText");
        titleObj.transform.SetParent(canvas.transform, false);

        TextMeshProUGUI titleText = titleObj.AddComponent<TextMeshProUGUI>();
        titleText.text = "SEL-EN";
        titleText.fontStyle = FontStyles.Bold;
        titleText.fontSize = 80;
        titleText.color = Color.cyan;
        titleText.alignment = TextAlignmentOptions.Center;

        RectTransform titleRect = titleObj.GetComponent<RectTransform>();
        titleRect.anchorMin = new Vector2(0.5f, 1f);
        titleRect.anchorMax = new Vector2(0.5f, 1f);
        titleRect.pivot = new Vector2(0.5f, 1f);
        titleRect.anchoredPosition = new Vector2(0, -50);
        titleRect.sizeDelta = new Vector2(600, 120);

        // Mark scene as dirty
        UnityEditor.SceneManagement.EditorSceneManager.MarkSceneDirty(canvas.gameObject.scene);
        
        Debug.Log("Leaderboard visuals improved successfully.");
    }
}
