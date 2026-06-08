using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro;

public class FinalizeLosePanel
{
    public static void Execute()
    {
        GameObject canvas = GameObject.Find("Canvas");
        if (canvas == null) return;

        Transform losePanelTransform = canvas.transform.Find("LosePanel");
        if (losePanelTransform == null) return;

        GameObject losePanel = losePanelTransform.gameObject;

        // 1. Fix Title (SonucYazisi)
        Transform sonucYazisiTransform = losePanel.transform.Find("SonucYazisi");
        if (sonucYazisiTransform != null)
        {
            RectTransform textRect = sonucYazisiTransform.GetComponent<RectTransform>();
            textRect.anchoredPosition = new Vector2(0, -150); // Move down slightly
            
            TextMeshProUGUI tmp = sonucYazisiTransform.GetComponent<TextMeshProUGUI>();
            if (tmp != null)
            {
                tmp.text = "KAYBETTİN!";
                tmp.fontSize = 48;
                tmp.color = Color.white;
                
                // Add a subtle red glow using outline
                tmp.outlineWidth = 0.15f;
                tmp.outlineColor = new Color32(255, 50, 50, 200);
            }
        }

        // 2. Fix Warning Icon
        Transform iconTransform = losePanel.transform.Find("WarningIcon");
        if (iconTransform != null)
        {
            RectTransform iconRect = iconTransform.GetComponent<RectTransform>();
            iconRect.anchoredPosition = new Vector2(0, -60); // Move down slightly
            iconRect.sizeDelta = new Vector2(60, 60);
            
            Image iconImg = iconTransform.GetComponent<Image>();
            if (iconImg != null)
            {
                // Try to find a warning icon sprite, otherwise use a red circle
                Sprite warningSprite = AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/Knob.psd");
                if (warningSprite != null)
                {
                    iconImg.sprite = warningSprite;
                    iconImg.color = new Color(1f, 0.2f, 0.2f, 1f);
                }
            }
        }

        // 3. Fix Buttons
        Transform replayBtnTransform = losePanel.transform.Find("LoseReplayButton");
        if (replayBtnTransform != null)
        {
            RectTransform rect = replayBtnTransform.GetComponent<RectTransform>();
            rect.anchoredPosition = new Vector2(0, -250);
        }

        Transform exitBtnTransform = losePanel.transform.Find("LoseExitButton");
        if (exitBtnTransform != null)
        {
            RectTransform rect = exitBtnTransform.GetComponent<RectTransform>();
            rect.anchoredPosition = new Vector2(0, -330);
        }

        // Hide the panel again
        losePanel.SetActive(false);

        EditorUtility.SetDirty(losePanel);
        UnityEditor.SceneManagement.EditorSceneManager.MarkSceneDirty(UnityEditor.SceneManagement.EditorSceneManager.GetActiveScene());
        Debug.Log("LosePanel finalized and hidden.");
    }
}
