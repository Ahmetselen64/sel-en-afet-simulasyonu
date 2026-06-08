using UnityEngine;
using UnityEditor;
using UnityEditor.Events;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class SetupNewsUI
{
    public static void Execute()
    {
        GameObject canvas = GameObject.Find("Canvas");
        if (canvas == null)
        {
            Debug.LogError("Canvas not found!");
            return;
        }

        MainMenuManager mainMenuManager = canvas.GetComponent<MainMenuManager>();
        if (mainMenuManager == null)
        {
            Debug.LogError("MainMenuManager not found on Canvas!");
            return;
        }

        // Create NewsPanel
        GameObject newsPanel = new GameObject("NewsPanel");
        newsPanel.transform.SetParent(canvas.transform, false);
        
        Image panelImage = newsPanel.AddComponent<Image>();
        panelImage.color = new Color(0.5f, 0f, 0f, 0.9f); // Dark red semi-transparent
        
        RectTransform panelRect = newsPanel.GetComponent<RectTransform>();
        panelRect.anchorMin = new Vector2(0, 0);
        panelRect.anchorMax = new Vector2(1, 1);
        panelRect.offsetMin = Vector2.zero;
        panelRect.offsetMax = Vector2.zero;

        // Create NewsText
        GameObject newsTextObj = new GameObject("NewsText");
        newsTextObj.transform.SetParent(newsPanel.transform, false);
        
        TextMeshProUGUI newsText = newsTextObj.AddComponent<TextMeshProUGUI>();
        newsText.text = "DİKKAT! Bölgede şiddetli yağış nedeniyle sel riski bulunmaktadır. Lütfen yapılacaklar listesindeki talimatlara uyunuz.";
        newsText.color = Color.white;
        newsText.alignment = TextAlignmentOptions.Center;
        newsText.fontSize = 36;
        newsText.enableWordWrapping = true;
        
        RectTransform textRect = newsTextObj.GetComponent<RectTransform>();
        textRect.anchorMin = new Vector2(0.1f, 0.3f);
        textRect.anchorMax = new Vector2(0.9f, 0.9f);
        textRect.offsetMin = Vector2.zero;
        textRect.offsetMax = Vector2.zero;

        // Create ContinueButton
        GameObject buttonObj = new GameObject("ContinueButton");
        buttonObj.transform.SetParent(newsPanel.transform, false);
        
        Image buttonImage = buttonObj.AddComponent<Image>();
        buttonImage.color = new Color(0.2f, 0.2f, 0.2f, 1f);
        
        Button continueButton = buttonObj.AddComponent<Button>();
        
        RectTransform buttonRect = buttonObj.GetComponent<RectTransform>();
        buttonRect.anchorMin = new Vector2(0.5f, 0.1f);
        buttonRect.anchorMax = new Vector2(0.5f, 0.1f);
        buttonRect.sizeDelta = new Vector2(400, 80);
        buttonRect.anchoredPosition = new Vector2(0, 50);

        // Create Button Text
        GameObject buttonTextObj = new GameObject("Text (TMP)");
        buttonTextObj.transform.SetParent(buttonObj.transform, false);
        
        TextMeshProUGUI buttonText = buttonTextObj.AddComponent<TextMeshProUGUI>();
        buttonText.text = "TALİMATLARI ANLADIM";
        buttonText.color = Color.white;
        buttonText.alignment = TextAlignmentOptions.Center;
        buttonText.fontSize = 24;
        
        RectTransform buttonTextRect = buttonTextObj.GetComponent<RectTransform>();
        buttonTextRect.anchorMin = new Vector2(0, 0);
        buttonTextRect.anchorMax = new Vector2(1, 1);
        buttonTextRect.offsetMin = Vector2.zero;
        buttonTextRect.offsetMax = Vector2.zero;

        // Assign to MainMenuManager
        mainMenuManager.NewsPanel = newsPanel;

        // Link Button to ConfirmNews
        UnityEventTools.AddPersistentListener(continueButton.onClick, mainMenuManager.ConfirmNews);

        // Hide NewsPanel by default
        newsPanel.SetActive(false);

        Debug.Log("News UI setup complete!");
    }
}
