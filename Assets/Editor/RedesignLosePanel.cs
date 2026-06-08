using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro;

public class RedesignLosePanel
{
    public static void Execute()
    {
        GameObject canvas = GameObject.Find("Canvas");
        if (canvas == null)
        {
            Debug.LogError("Canvas not found");
            return;
        }

        Transform losePanelTransform = canvas.transform.Find("LosePanel");
        if (losePanelTransform == null)
        {
            Debug.LogError("LosePanel not found");
            return;
        }

        GameObject losePanel = losePanelTransform.gameObject;
        RectTransform panelRect = losePanel.GetComponent<RectTransform>();
        panelRect.sizeDelta = new Vector2(600, 400);

        // 1. Background
        Image panelImage = losePanel.GetComponent<Image>();
        if (panelImage != null)
        {
            Color bgColor;
            ColorUtility.TryParseHtmlString("#1A2530E6", out bgColor); // Dark moody blue with 90% alpha
            panelImage.color = bgColor;
        }

        // 2. Title (SonucYazisi)
        GameObject sonucYazisi = GameObject.Find("Canvas/SonucYazisi");
        if (sonucYazisi != null)
        {
            sonucYazisi.transform.SetParent(losePanel.transform, true);
            RectTransform textRect = sonucYazisi.GetComponent<RectTransform>();
            textRect.anchorMin = new Vector2(0.5f, 1f);
            textRect.anchorMax = new Vector2(0.5f, 1f);
            textRect.pivot = new Vector2(0.5f, 1f);
            textRect.anchoredPosition = new Vector2(0, -80);
            textRect.sizeDelta = new Vector2(550, 100);

            TextMeshProUGUI tmp = sonucYazisi.GetComponent<TextMeshProUGUI>();
            if (tmp != null)
            {
                tmp.color = Color.white;
                tmp.fontStyle = FontStyles.Bold;
                tmp.fontSize = 36;
                tmp.alignment = TextAlignmentOptions.Center;
                
                // Add red glow (outline)
                tmp.outlineWidth = 0.2f;
                tmp.outlineColor = new Color32(255, 0, 0, 128);
            }
        }

        // Add Warning Icon Placeholder
        Transform iconTransform = losePanel.transform.Find("WarningIcon");
        GameObject iconObj;
        if (iconTransform == null)
        {
            iconObj = new GameObject("WarningIcon");
            iconObj.transform.SetParent(losePanel.transform, false);
            Image iconImg = iconObj.AddComponent<Image>();
            iconImg.color = new Color(1f, 0.2f, 0.2f, 0.8f); // Reddish placeholder
        }
        else
        {
            iconObj = iconTransform.gameObject;
        }
        RectTransform iconRect = iconObj.GetComponent<RectTransform>();
        iconRect.anchorMin = new Vector2(0.5f, 1f);
        iconRect.anchorMax = new Vector2(0.5f, 1f);
        iconRect.pivot = new Vector2(0.5f, 1f);
        iconRect.anchoredPosition = new Vector2(0, -20);
        iconRect.sizeDelta = new Vector2(50, 50);

        // 3. Buttons
        Color btnColor;
        ColorUtility.TryParseHtmlString("#0088CCE6", out btnColor); // Watery cyan blue

        Transform replayBtnTransform = losePanel.transform.Find("LoseReplayButton");
        if (replayBtnTransform != null)
        {
            Image btnImg = replayBtnTransform.GetComponent<Image>();
            if (btnImg != null) btnImg.color = btnColor;

            RectTransform rect = replayBtnTransform.GetComponent<RectTransform>();
            rect.anchorMin = new Vector2(0.5f, 0.5f);
            rect.anchorMax = new Vector2(0.5f, 0.5f);
            rect.pivot = new Vector2(0.5f, 0.5f);
            rect.anchoredPosition = new Vector2(0, -20);
            rect.sizeDelta = new Vector2(200, 50);

            TextMeshProUGUI tmp = replayBtnTransform.GetComponentInChildren<TextMeshProUGUI>();
            if (tmp != null)
            {
                tmp.color = Color.white;
                tmp.fontStyle = FontStyles.Bold;
            }
        }

        Transform exitBtnTransform = losePanel.transform.Find("LoseExitButton");
        if (exitBtnTransform != null)
        {
            Image btnImg = exitBtnTransform.GetComponent<Image>();
            if (btnImg != null) btnImg.color = btnColor;

            RectTransform rect = exitBtnTransform.GetComponent<RectTransform>();
            rect.anchorMin = new Vector2(0.5f, 0.5f);
            rect.anchorMax = new Vector2(0.5f, 0.5f);
            rect.pivot = new Vector2(0.5f, 0.5f);
            rect.anchoredPosition = new Vector2(0, -90);
            rect.sizeDelta = new Vector2(200, 50);

            TextMeshProUGUI tmp = exitBtnTransform.GetComponentInChildren<TextMeshProUGUI>();
            if (tmp != null)
            {
                tmp.color = Color.white;
                tmp.fontStyle = FontStyles.Bold;
            }
        }

        EditorUtility.SetDirty(losePanel);
        if (sonucYazisi != null) EditorUtility.SetDirty(sonucYazisi);
        UnityEditor.SceneManagement.EditorSceneManager.MarkSceneDirty(UnityEditor.SceneManagement.EditorSceneManager.GetActiveScene());
        Debug.Log("LosePanel redesigned successfully.");
    }
}
