using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro;

public class RefineLosePanelDesign
{
    public static void Execute()
    {
        GameObject canvas = GameObject.Find("Canvas");
        if (canvas == null) return;

        Transform losePanelTransform = canvas.transform.Find("LosePanel");
        if (losePanelTransform == null) return;

        GameObject losePanel = losePanelTransform.gameObject;
        RectTransform panelRect = losePanel.GetComponent<RectTransform>();
        panelRect.sizeDelta = new Vector2(600, 450);

        // 1. Background
        Image panelImage = losePanel.GetComponent<Image>();
        if (panelImage != null)
        {
            ColorUtility.TryParseHtmlString("#1A2530F2", out Color bgColor); // Dark moody blue, 95% opacity
            panelImage.color = bgColor;
        }

        // 2. Title
        GameObject sonucYazisi = GameObject.Find("Canvas/SonucYazisi");
        if (sonucYazisi == null)
        {
            Transform t = losePanel.transform.Find("SonucYazisi");
            if (t != null) sonucYazisi = t.gameObject;
        }

        if (sonucYazisi != null)
        {
            sonucYazisi.transform.SetParent(losePanel.transform, true);
            RectTransform textRect = sonucYazisi.GetComponent<RectTransform>();
            textRect.anchorMin = new Vector2(0.5f, 1f);
            textRect.anchorMax = new Vector2(0.5f, 1f);
            textRect.pivot = new Vector2(0.5f, 1f);
            textRect.anchoredPosition = new Vector2(0, -100);
            textRect.sizeDelta = new Vector2(550, 120);

            TextMeshProUGUI tmp = sonucYazisi.GetComponent<TextMeshProUGUI>();
            if (tmp != null)
            {
                tmp.color = Color.white;
                tmp.fontStyle = FontStyles.Bold;
                tmp.fontSize = 32;
                tmp.alignment = TextAlignmentOptions.Center;
                
                // Red glow
                tmp.fontSharedMaterial.EnableKeyword("GLOW_ON");
                tmp.fontSharedMaterial.SetColor("_GlowColor", new Color(1f, 0f, 0f, 0.6f));
                tmp.fontSharedMaterial.SetFloat("_GlowOffset", 0.1f);
                tmp.fontSharedMaterial.SetFloat("_GlowOuter", 0.3f);
            }
        }

        // Warning Icon
        Transform iconTransform = losePanel.transform.Find("WarningIcon");
        GameObject iconObj;
        if (iconTransform == null)
        {
            iconObj = new GameObject("WarningIcon");
            iconObj.transform.SetParent(losePanel.transform, false);
            Image iconImg = iconObj.AddComponent<Image>();
            iconImg.color = new Color(1f, 0.2f, 0.2f, 1f);
        }
        else
        {
            iconObj = iconTransform.gameObject;
        }
        RectTransform iconRect = iconObj.GetComponent<RectTransform>();
        iconRect.anchorMin = new Vector2(0.5f, 1f);
        iconRect.anchorMax = new Vector2(0.5f, 1f);
        iconRect.pivot = new Vector2(0.5f, 1f);
        iconRect.anchoredPosition = new Vector2(0, -30);
        iconRect.sizeDelta = new Vector2(60, 60);

        // 3. Buttons
        Color btnColor;
        ColorUtility.TryParseHtmlString("#0088CC", out btnColor); // Watery cyan blue

        Sprite roundedSprite = AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/UISprite.psd");

        Transform replayBtnTransform = losePanel.transform.Find("LoseReplayButton");
        if (replayBtnTransform != null)
        {
            Image btnImg = replayBtnTransform.GetComponent<Image>();
            if (btnImg != null)
            {
                btnImg.color = btnColor;
                btnImg.sprite = roundedSprite;
                btnImg.type = Image.Type.Sliced;
            }

            RectTransform rect = replayBtnTransform.GetComponent<RectTransform>();
            rect.anchorMin = new Vector2(0.5f, 1f);
            rect.anchorMax = new Vector2(0.5f, 1f);
            rect.pivot = new Vector2(0.5f, 1f);
            rect.anchoredPosition = new Vector2(0, -250);
            rect.sizeDelta = new Vector2(250, 60);

            TextMeshProUGUI tmp = replayBtnTransform.GetComponentInChildren<TextMeshProUGUI>();
            if (tmp != null)
            {
                tmp.color = Color.white;
                tmp.fontStyle = FontStyles.Bold;
                tmp.fontSize = 24;
            }
        }

        Transform exitBtnTransform = losePanel.transform.Find("LoseExitButton");
        if (exitBtnTransform != null)
        {
            Image btnImg = exitBtnTransform.GetComponent<Image>();
            if (btnImg != null)
            {
                btnImg.color = btnColor;
                btnImg.sprite = roundedSprite;
                btnImg.type = Image.Type.Sliced;
            }

            RectTransform rect = exitBtnTransform.GetComponent<RectTransform>();
            rect.anchorMin = new Vector2(0.5f, 1f);
            rect.anchorMax = new Vector2(0.5f, 1f);
            rect.pivot = new Vector2(0.5f, 1f);
            rect.anchoredPosition = new Vector2(0, -330);
            rect.sizeDelta = new Vector2(250, 60);

            TextMeshProUGUI tmp = exitBtnTransform.GetComponentInChildren<TextMeshProUGUI>();
            if (tmp != null)
            {
                tmp.color = Color.white;
                tmp.fontStyle = FontStyles.Bold;
                tmp.fontSize = 24;
            }
        }

        EditorUtility.SetDirty(losePanel);
        UnityEditor.SceneManagement.EditorSceneManager.MarkSceneDirty(UnityEditor.SceneManagement.EditorSceneManager.GetActiveScene());
        Debug.Log("LosePanel refined successfully.");
    }
}
