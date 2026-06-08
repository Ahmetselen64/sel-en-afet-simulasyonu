using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro;

public class SetupExitButton
{
    [MenuItem("Tools/Setup Exit Button")]
    public static void Setup()
    {
        Canvas canvas = Object.FindFirstObjectByType<Canvas>();
        if (canvas == null)
        {
            Debug.LogError("Canvas not found!");
            return;
        }

        // Create ExitButton
        GameObject buttonGO = new GameObject("ExitButton");
        buttonGO.transform.SetParent(canvas.transform, false);
        RectTransform buttonRect = buttonGO.AddComponent<RectTransform>();
        buttonRect.anchoredPosition = new Vector2(0, -200); // Positioned at the bottom
        buttonRect.sizeDelta = new Vector2(160, 40);
        Image buttonImage = buttonGO.AddComponent<Image>();
        buttonImage.color = Color.white;
        Button button = buttonGO.AddComponent<Button>();

        // Button Text
        GameObject btnTextGO = new GameObject("Text (TMP)");
        btnTextGO.transform.SetParent(buttonGO.transform, false);
        RectTransform btnTextRect = btnTextGO.AddComponent<RectTransform>();
        btnTextRect.anchorMin = Vector2.zero;
        btnTextRect.anchorMax = Vector2.one;
        btnTextRect.offsetMin = Vector2.zero;
        btnTextRect.offsetMax = Vector2.zero;
        TextMeshProUGUI btnTextTMP = btnTextGO.AddComponent<TextMeshProUGUI>();
        btnTextTMP.text = "Çıkış";
        btnTextTMP.color = Color.black;
        btnTextTMP.alignment = TextAlignmentOptions.Center;
        btnTextTMP.fontSize = 24;

        // Assign to LeaderboardManager
        LeaderboardManager manager = canvas.GetComponent<LeaderboardManager>();
        if (manager != null)
        {
            manager.exitButton = button;
        }

        Undo.RegisterCreatedObjectUndo(buttonGO, "Create Exit Button");
    }
}
