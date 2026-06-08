using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using UnityEditor.Events;

public class SetupLeaderboardButton
{
    public static void Execute()
    {
        GameObject canvas = GameObject.Find("Canvas");
        if (canvas == null)
        {
            Debug.LogError("Canvas not found");
            return;
        }

        Transform winPanel = canvas.transform.Find("WinPanel");
        if (winPanel == null)
        {
            winPanel = canvas.transform.Find("WinText");
            if (winPanel != null)
            {
                winPanel.name = "WinPanel";
            }
            else
            {
                winPanel = new GameObject("WinPanel").transform;
                winPanel.SetParent(canvas.transform, false);
            }
        }

        GameObject buttonObj = new GameObject("LeaderboardButton");
        buttonObj.transform.SetParent(winPanel, false);
        
        RectTransform rectTransform = buttonObj.AddComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(0, -100);
        rectTransform.sizeDelta = new Vector2(200, 50);

        Image image = buttonObj.AddComponent<Image>();
        Button button = buttonObj.AddComponent<Button>();

        GameObject textObj = new GameObject("Text (TMP)");
        textObj.transform.SetParent(buttonObj.transform, false);
        
        RectTransform textRect = textObj.AddComponent<RectTransform>();
        textRect.anchorMin = Vector2.zero;
        textRect.anchorMax = Vector2.one;
        textRect.sizeDelta = Vector2.zero;
        textRect.anchoredPosition = Vector2.zero;

        TextMeshProUGUI text = textObj.AddComponent<TextMeshProUGUI>();
        text.text = "Skoru Kaydet";
        text.color = Color.black;
        text.alignment = TextAlignmentOptions.Center;
        text.fontSize = 24;

        LeaderboardButton lbScript = buttonObj.AddComponent<LeaderboardButton>();
        
        UnityEventTools.AddPersistentListener(button.onClick, lbScript.OnLeaderboardButtonClicked);

        EditorUtility.SetDirty(winPanel.gameObject);
        Debug.Log("LeaderboardButton created successfully.");
    }
}
