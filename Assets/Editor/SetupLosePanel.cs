using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SetupLosePanel
{
    public static void Execute()
    {
        GameObject canvas = GameObject.Find("Canvas");
        if (canvas == null)
        {
            Debug.LogError("Canvas not found");
            return;
        }

        // Find or create LosePanel
        Transform losePanelTransform = canvas.transform.Find("LosePanel");
        GameObject losePanel;
        if (losePanelTransform == null)
        {
            losePanel = new GameObject("LosePanel");
            losePanel.transform.SetParent(canvas.transform, false);
            RectTransform rect = losePanel.AddComponent<RectTransform>();
            rect.anchorMin = new Vector2(0.5f, 0.5f);
            rect.anchorMax = new Vector2(0.5f, 0.5f);
            rect.anchoredPosition = Vector2.zero;
            rect.sizeDelta = new Vector2(400, 200);
            
            Image img = losePanel.AddComponent<Image>();
            img.color = new Color(0, 0, 0, 0.8f);
            
            losePanel.SetActive(false);
        }
        else
        {
            losePanel = losePanelTransform.gameObject;
        }

        // Create LoseReplayButton
        Transform replayBtnTransform = losePanel.transform.Find("LoseReplayButton");
        GameObject replayButtonObj;
        if (replayBtnTransform == null)
        {
            replayButtonObj = new GameObject("LoseReplayButton");
            replayButtonObj.transform.SetParent(losePanel.transform, false);
            RectTransform rect = replayButtonObj.AddComponent<RectTransform>();
            rect.anchorMin = new Vector2(0.5f, 0.5f);
            rect.anchorMax = new Vector2(0.5f, 0.5f);
            rect.anchoredPosition = new Vector2(0, 30);
            rect.sizeDelta = new Vector2(160, 40);
            
            Image img = replayButtonObj.AddComponent<Image>();
            Button btn = replayButtonObj.AddComponent<Button>();
            
            GameObject textObj = new GameObject("Text (TMP)");
            textObj.transform.SetParent(replayButtonObj.transform, false);
            RectTransform textRect = textObj.AddComponent<RectTransform>();
            textRect.anchorMin = Vector2.zero;
            textRect.anchorMax = Vector2.one;
            textRect.sizeDelta = Vector2.zero;
            
            TextMeshProUGUI text = textObj.AddComponent<TextMeshProUGUI>();
            text.text = "Tekrar Oyna";
            text.color = Color.black;
            text.alignment = TextAlignmentOptions.Center;
            text.fontSize = 24;
        }
        else
        {
            replayButtonObj = replayBtnTransform.gameObject;
        }

        // Create LoseExitButton
        Transform exitBtnTransform = losePanel.transform.Find("LoseExitButton");
        GameObject exitButtonObj;
        if (exitBtnTransform == null)
        {
            exitButtonObj = new GameObject("LoseExitButton");
            exitButtonObj.transform.SetParent(losePanel.transform, false);
            RectTransform rect = exitButtonObj.AddComponent<RectTransform>();
            rect.anchorMin = new Vector2(0.5f, 0.5f);
            rect.anchorMax = new Vector2(0.5f, 0.5f);
            rect.anchoredPosition = new Vector2(0, -30);
            rect.sizeDelta = new Vector2(160, 40);
            
            Image img = exitButtonObj.AddComponent<Image>();
            Button btn = exitButtonObj.AddComponent<Button>();
            
            GameObject textObj = new GameObject("Text (TMP)");
            textObj.transform.SetParent(exitButtonObj.transform, false);
            RectTransform textRect = textObj.AddComponent<RectTransform>();
            textRect.anchorMin = Vector2.zero;
            textRect.anchorMax = Vector2.one;
            textRect.sizeDelta = Vector2.zero;
            
            TextMeshProUGUI text = textObj.AddComponent<TextMeshProUGUI>();
            text.text = "Çıkış";
            text.color = Color.black;
            text.alignment = TextAlignmentOptions.Center;
            text.fontSize = 24;
        }
        else
        {
            exitButtonObj = exitBtnTransform.gameObject;
        }

        UnityEditor.SceneManagement.EditorSceneManager.MarkSceneDirty(UnityEditor.SceneManagement.EditorSceneManager.GetActiveScene());
        Debug.Log("LosePanel and buttons created successfully.");
    }
}
