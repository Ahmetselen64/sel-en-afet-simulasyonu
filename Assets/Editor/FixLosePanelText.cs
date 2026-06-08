using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro;

public class FixLosePanelText
{
    public static void Execute()
    {
        GameObject canvas = GameObject.Find("Canvas");
        if (canvas == null) return;

        Transform losePanelTransform = canvas.transform.Find("LosePanel");
        if (losePanelTransform == null) return;

        GameObject losePanel = losePanelTransform.gameObject;

        // Fix Title (SonucYazisi)
        Transform sonucYazisiTransform = losePanel.transform.Find("SonucYazisi");
        if (sonucYazisiTransform != null)
        {
            TextMeshProUGUI tmp = sonucYazisiTransform.GetComponent<TextMeshProUGUI>();
            if (tmp != null)
            {
                // Ensure the text is visible and on top
                tmp.text = "KAYBETTİN!";
                tmp.color = Color.white;
                tmp.fontSize = 48;
                tmp.alignment = TextAlignmentOptions.Center;
                
                // Remove the glow if it's causing issues, or set it properly
                tmp.fontSharedMaterial.DisableKeyword("GLOW_ON");
                tmp.outlineWidth = 0.2f;
                tmp.outlineColor = new Color32(255, 0, 0, 255);
            }
            
            RectTransform textRect = sonucYazisiTransform.GetComponent<RectTransform>();
            textRect.anchoredPosition = new Vector2(0, -120);
            
            // Ensure it's the last sibling so it renders on top
            sonucYazisiTransform.SetAsLastSibling();
        }

        // Fix Warning Icon
        Transform iconTransform = losePanel.transform.Find("WarningIcon");
        if (iconTransform != null)
        {
            RectTransform iconRect = iconTransform.GetComponent<RectTransform>();
            iconRect.anchoredPosition = new Vector2(0, -40);
            iconTransform.SetAsLastSibling();
        }

        // Fix Buttons
        Transform replayBtnTransform = losePanel.transform.Find("LoseReplayButton");
        if (replayBtnTransform != null)
        {
            replayBtnTransform.SetAsLastSibling();
        }

        Transform exitBtnTransform = losePanel.transform.Find("LoseExitButton");
        if (exitBtnTransform != null)
        {
            exitBtnTransform.SetAsLastSibling();
        }

        EditorUtility.SetDirty(losePanel);
        UnityEditor.SceneManagement.EditorSceneManager.MarkSceneDirty(UnityEditor.SceneManagement.EditorSceneManager.GetActiveScene());
        Debug.Log("LosePanel text fixed.");
    }
}
