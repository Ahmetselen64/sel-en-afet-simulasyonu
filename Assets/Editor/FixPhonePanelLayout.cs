using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro;

public class FixPhonePanelLayout
{
    public static void Execute()
    {
        GameObject canvas = GameObject.Find("Canvas");
        if (canvas == null) return;

        Transform panelTransform = canvas.transform.Find("TelefonPaneli");
        if (panelTransform == null) return;

        // 1. Fix EkranYazisi (Screen Text)
        Transform ekranYazisi = panelTransform.Find("EkranYazisi");
        if (ekranYazisi != null)
        {
            RectTransform ekranRect = ekranYazisi.GetComponent<RectTransform>();
            if (ekranRect != null)
            {
                ekranRect.anchorMin = new Vector2(0.5f, 1f);
                ekranRect.anchorMax = new Vector2(0.5f, 1f);
                ekranRect.pivot = new Vector2(0.5f, 1f);
                ekranRect.anchoredPosition = new Vector2(0, -50); // 50 units from top
                ekranRect.sizeDelta = new Vector2(300, 100);
            }

            TMP_Text textComp = ekranYazisi.GetComponent<TMP_Text>();
            if (textComp != null)
            {
                textComp.alignment = TextAlignmentOptions.Center;
                textComp.color = Color.white;
                textComp.text = ""; // Clear it so it looks like an empty screen
            }
        }

        // 2. Fix "New Text" stray text
        // It might be a different object. Let's search for it.
        foreach (Transform child in canvas.transform)
        {
            TMP_Text t = child.GetComponent<TMP_Text>();
            if (t != null && t.text == "New Text")
            {
                child.gameObject.SetActive(false); // Hide it
            }
        }

        // 3. Adjust ButtonGrid position
        Transform gridTransform = panelTransform.Find("ButtonGrid");
        if (gridTransform != null)
        {
            RectTransform gridRect = gridTransform.GetComponent<RectTransform>();
            if (gridRect != null)
            {
                gridRect.anchorMin = new Vector2(0.5f, 0.5f);
                gridRect.anchorMax = new Vector2(0.5f, 0.5f);
                gridRect.pivot = new Vector2(0.5f, 0.5f);
                gridRect.anchoredPosition = new Vector2(0, -20); // Center it vertically
                gridRect.sizeDelta = new Vector2(300, 400);
            }
        }

        // 4. Adjust Call Button position
        Transform callBtnTransform = panelTransform.Find("CallButton");
        if (callBtnTransform != null)
        {
            RectTransform callRect = callBtnTransform.GetComponent<RectTransform>();
            if (callRect != null)
            {
                callRect.anchorMin = new Vector2(0.5f, 0f);
                callRect.anchorMax = new Vector2(0.5f, 0f);
                callRect.pivot = new Vector2(0.5f, 0f);
                callRect.anchoredPosition = new Vector2(0, 60); // 60 units from bottom
            }
        }

        EditorUtility.SetDirty(panelTransform.gameObject);
    }
}