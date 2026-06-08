using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class SetupMainMenuUI
{
    [MenuItem("Tools/Setup Main Menu UI")]
    public static void Setup()
    {
        // Find Canvas
        Canvas canvas = Object.FindObjectOfType<Canvas>();
        if (canvas == null)
        {
            Debug.LogError("No Canvas found in the scene.");
            return;
        }

        // Create MainMenuPanel
        GameObject panelObj = new GameObject("MainMenuPanel");
        panelObj.transform.SetParent(canvas.transform, false);
        RectTransform panelRect = panelObj.AddComponent<RectTransform>();
        panelRect.anchorMin = new Vector2(0, 0);
        panelRect.anchorMax = new Vector2(1, 1);
        panelRect.offsetMin = Vector2.zero;
        panelRect.offsetMax = Vector2.zero;
        Image panelImage = panelObj.AddComponent<Image>();
        panelImage.color = new Color(0, 0, 0, 0.8f);

        // Create GameTitleText
        GameObject titleObj = new GameObject("GameTitleText");
        titleObj.transform.SetParent(panelObj.transform, false);
        RectTransform titleRect = titleObj.AddComponent<RectTransform>();
        titleRect.anchorMin = new Vector2(0.5f, 0.7f);
        titleRect.anchorMax = new Vector2(0.5f, 0.9f);
        titleRect.sizeDelta = new Vector2(800, 200);
        titleRect.anchoredPosition = Vector2.zero;
        TextMeshProUGUI titleText = titleObj.AddComponent<TextMeshProUGUI>();
        titleText.text = "AFET SİMÜLASYONU";
        titleText.fontSize = 72;
        titleText.color = Color.yellow;
        titleText.fontStyle = FontStyles.Bold;
        titleText.alignment = TextAlignmentOptions.Center;

        // Create StartButton
        GameObject buttonObj = new GameObject("StartButton");
        buttonObj.transform.SetParent(panelObj.transform, false);
        RectTransform buttonRect = buttonObj.AddComponent<RectTransform>();
        buttonRect.anchorMin = new Vector2(0.5f, 0.4f);
        buttonRect.anchorMax = new Vector2(0.5f, 0.4f);
        buttonRect.sizeDelta = new Vector2(300, 80);
        buttonRect.anchoredPosition = Vector2.zero;
        Image buttonImage = buttonObj.AddComponent<Image>();
        buttonImage.color = Color.white;
        Button startButton = buttonObj.AddComponent<Button>();

        // Create StartButton Text
        GameObject buttonTextObj = new GameObject("Text (TMP)");
        buttonTextObj.transform.SetParent(buttonObj.transform, false);
        RectTransform buttonTextRect = buttonTextObj.AddComponent<RectTransform>();
        buttonTextRect.anchorMin = Vector2.zero;
        buttonTextRect.anchorMax = Vector2.one;
        buttonTextRect.offsetMin = Vector2.zero;
        buttonTextRect.offsetMax = Vector2.zero;
        TextMeshProUGUI buttonText = buttonTextObj.AddComponent<TextMeshProUGUI>();
        buttonText.text = "OYUNA BAŞLA";
        buttonText.fontSize = 36;
        buttonText.color = Color.black;
        buttonText.alignment = TextAlignmentOptions.Center;

        // Attach MainMenuManager to Canvas
        MainMenuManager manager = canvas.gameObject.GetComponent<MainMenuManager>();
        if (manager == null)
        {
            manager = canvas.gameObject.AddComponent<MainMenuManager>();
        }
        manager.MainMenuPanel = panelObj;

        // Link StartButton onClick
        UnityEditor.Events.UnityEventTools.AddPersistentListener(startButton.onClick, manager.StartGame);

        Debug.Log("Main Menu UI setup complete.");
    }
}
