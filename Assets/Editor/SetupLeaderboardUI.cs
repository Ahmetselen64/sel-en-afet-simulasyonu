using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class SetupLeaderboardUI
{
    [MenuItem("Tools/Setup Leaderboard UI")]
    public static void Setup()
    {
        // Create EventSystem if it doesn't exist
        if (Object.FindFirstObjectByType<EventSystem>() == null)
        {
            GameObject eventSystem = new GameObject("EventSystem");
            eventSystem.AddComponent<EventSystem>();
            eventSystem.AddComponent<StandaloneInputModule>();
        }

        // Create Canvas
        GameObject canvasGO = new GameObject("Canvas");
        Canvas canvas = canvasGO.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvasGO.AddComponent<CanvasScaler>();
        canvasGO.AddComponent<GraphicRaycaster>();

        // Create NameInput (TMP_InputField)
        GameObject inputGO = new GameObject("NameInput");
        inputGO.transform.SetParent(canvasGO.transform, false);
        RectTransform inputRect = inputGO.AddComponent<RectTransform>();
        inputRect.anchoredPosition = new Vector2(0, 100);
        inputRect.sizeDelta = new Vector2(200, 40);
        Image inputImage = inputGO.AddComponent<Image>();
        inputImage.color = Color.white;
        TMP_InputField inputField = inputGO.AddComponent<TMP_InputField>();

        // InputField Text Area
        GameObject textAreaGO = new GameObject("Text Area");
        textAreaGO.transform.SetParent(inputGO.transform, false);
        RectTransform textAreaRect = textAreaGO.AddComponent<RectTransform>();
        textAreaRect.anchorMin = Vector2.zero;
        textAreaRect.anchorMax = Vector2.one;
        textAreaRect.offsetMin = new Vector2(10, 6);
        textAreaRect.offsetMax = new Vector2(-10, -7);
        textAreaGO.AddComponent<RectMask2D>();

        // InputField Text
        GameObject textGO = new GameObject("Text");
        textGO.transform.SetParent(textAreaGO.transform, false);
        RectTransform textRect = textGO.AddComponent<RectTransform>();
        textRect.anchorMin = Vector2.zero;
        textRect.anchorMax = Vector2.one;
        textRect.offsetMin = Vector2.zero;
        textRect.offsetMax = Vector2.zero;
        TextMeshProUGUI textTMP = textGO.AddComponent<TextMeshProUGUI>();
        textTMP.color = Color.black;
        textTMP.fontSize = 24;
        
        inputField.textViewport = textAreaRect;
        inputField.textComponent = textTMP;

        // Create SaveButton
        GameObject buttonGO = new GameObject("SaveButton");
        buttonGO.transform.SetParent(canvasGO.transform, false);
        RectTransform buttonRect = buttonGO.AddComponent<RectTransform>();
        buttonRect.anchoredPosition = new Vector2(0, 0);
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
        btnTextTMP.text = "Kaydet";
        btnTextTMP.color = Color.black;
        btnTextTMP.alignment = TextAlignmentOptions.Center;
        btnTextTMP.fontSize = 24;

        // Create LeaderboardText
        GameObject lbTextGO = new GameObject("LeaderboardText");
        lbTextGO.transform.SetParent(canvasGO.transform, false);
        RectTransform lbTextRect = lbTextGO.AddComponent<RectTransform>();
        lbTextRect.anchoredPosition = new Vector2(0, -100);
        lbTextRect.sizeDelta = new Vector2(300, 100);
        TextMeshProUGUI lbTextTMP = lbTextGO.AddComponent<TextMeshProUGUI>();
        lbTextTMP.text = "Leaderboard";
        lbTextTMP.color = Color.white;
        lbTextTMP.alignment = TextAlignmentOptions.Center;
        lbTextTMP.fontSize = 24;

        // Attach LeaderboardManager
        LeaderboardManager manager = canvasGO.AddComponent<LeaderboardManager>();
        manager.nameInput = inputField;
        manager.saveButton = button;
        manager.leaderboardText = lbTextTMP;

        Undo.RegisterCreatedObjectUndo(canvasGO, "Create Leaderboard UI");
        if (Object.FindFirstObjectByType<EventSystem>() != null)
        {
            Undo.RegisterCreatedObjectUndo(Object.FindFirstObjectByType<EventSystem>().gameObject, "Create EventSystem");
        }
    }
}
