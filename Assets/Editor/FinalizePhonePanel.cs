using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro;

public class FinalizePhonePanel
{
    public static void Execute()
    {
        GameObject canvas = GameObject.Find("Canvas");
        if (canvas == null) return;

        Transform panelTransform = canvas.transform.Find("TelefonPaneli");
        if (panelTransform == null) return;

        // 1. Resize TelefonPaneli
        RectTransform panelRect = panelTransform.GetComponent<RectTransform>();
        if (panelRect != null)
        {
            panelRect.sizeDelta = new Vector2(350, 700);
        }

        // 2. Adjust EkranYazisi
        Transform ekranYazisi = panelTransform.Find("EkranYazisi");
        if (ekranYazisi != null)
        {
            RectTransform ekranRect = ekranYazisi.GetComponent<RectTransform>();
            if (ekranRect != null)
            {
                ekranRect.anchorMin = new Vector2(0.5f, 1f);
                ekranRect.anchorMax = new Vector2(0.5f, 1f);
                ekranRect.pivot = new Vector2(0.5f, 1f);
                ekranRect.anchoredPosition = new Vector2(0, -50);
                ekranRect.sizeDelta = new Vector2(300, 100);
            }

            TMP_Text textComp = ekranYazisi.GetComponent<TMP_Text>();
            if (textComp != null)
            {
                textComp.alignment = TextAlignmentOptions.Center;
                textComp.color = Color.white;
                textComp.text = ""; // Clear "New Text" if it's there, or leave it. Let's set it to a sample number or empty.
            }
        }

        // 3. Add '0' button and placeholders for grid
        Transform gridTransform = panelTransform.Find("ButtonGrid");
        if (gridTransform != null)
        {
            RectTransform gridRect = gridTransform.GetComponent<RectTransform>();
            if (gridRect != null)
            {
                gridRect.anchoredPosition = new Vector2(0, 120); // Move up slightly to make room for Call button
                gridRect.sizeDelta = new Vector2(300, 450); // Increase height for 4 rows
            }

            // Check if we already have 12 buttons
            int childCount = gridTransform.childCount;
            if (childCount == 9)
            {
                // Get a reference button to duplicate
                GameObject refButton = gridTransform.GetChild(8).gameObject;

                // Create Star button (invisible or just text "*")
                GameObject starBtn = GameObject.Instantiate(refButton, gridTransform);
                starBtn.name = "Buton_Star";
                TMP_Text starText = starBtn.GetComponentInChildren<TMP_Text>();
                if (starText != null) starText.text = "*";

                // Create 0 button
                GameObject zeroBtn = GameObject.Instantiate(refButton, gridTransform);
                zeroBtn.name = "Buton_0";
                TMP_Text zeroText = zeroBtn.GetComponentInChildren<TMP_Text>();
                if (zeroText != null) zeroText.text = "0";

                // Create Hash button
                GameObject hashBtn = GameObject.Instantiate(refButton, gridTransform);
                hashBtn.name = "Buton_Hash";
                TMP_Text hashText = hashBtn.GetComponentInChildren<TMP_Text>();
                if (hashText != null) hashText.text = "#";
            }
        }

        // 4. Add Call Button
        Transform callBtnTransform = panelTransform.Find("CallButton");
        if (callBtnTransform == null && gridTransform != null && gridTransform.childCount >= 9)
        {
            GameObject refButton = gridTransform.GetChild(8).gameObject;
            GameObject callBtn = GameObject.Instantiate(refButton, panelTransform);
            callBtn.name = "CallButton";
            
            RectTransform callRect = callBtn.GetComponent<RectTransform>();
            if (callRect != null)
            {
                callRect.anchorMin = new Vector2(0.5f, 0f);
                callRect.anchorMax = new Vector2(0.5f, 0f);
                callRect.pivot = new Vector2(0.5f, 0f);
                callRect.anchoredPosition = new Vector2(0, 40); // 40 units from bottom
                callRect.sizeDelta = new Vector2(80, 80);
            }

            Image callImage = callBtn.GetComponent<Image>();
            if (callImage != null)
            {
                ColorUtility.TryParseHtmlString("#34C759", out Color greenColor); // iOS green
                callImage.color = greenColor;
            }

            TMP_Text callText = callBtn.GetComponentInChildren<TMP_Text>();
            if (callText != null)
            {
                callText.text = "Ara";
                callText.fontSize = 24;
            }
        }

        EditorUtility.SetDirty(panelTransform.gameObject);
    }
}