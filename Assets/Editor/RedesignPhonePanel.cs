using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System.Linq;

public class RedesignPhonePanel
{
    public static void Execute()
    {
        GameObject canvas = GameObject.Find("Canvas");
        if (canvas == null) return;

        Transform panelTransform = canvas.transform.Find("TelefonPaneli");
        if (panelTransform == null) return;

        GameObject panel = panelTransform.gameObject;

        // 1. Panel Background
        Image panelImage = panel.GetComponent<Image>();
        if (panelImage != null)
        {
            ColorUtility.TryParseHtmlString("#1C1C1E", out Color panelColor);
            panelImage.color = panelColor;
            panelImage.sprite = AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/Background.psd");
            panelImage.type = Image.Type.Sliced;
        }

        // 2. Create ButtonGrid
        Transform gridTransform = panelTransform.Find("ButtonGrid");
        GameObject gridObj;
        if (gridTransform == null)
        {
            gridObj = new GameObject("ButtonGrid");
            gridObj.transform.SetParent(panelTransform, false);
        }
        else
        {
            gridObj = gridTransform.gameObject;
        }

        RectTransform gridRect = gridObj.GetComponent<RectTransform>();
        if (gridRect == null) gridRect = gridObj.AddComponent<RectTransform>();

        gridRect.anchorMin = new Vector2(0.5f, 0f);
        gridRect.anchorMax = new Vector2(0.5f, 0f);
        gridRect.pivot = new Vector2(0.5f, 0f);
        gridRect.anchoredPosition = new Vector2(0, 50); // 50 units from bottom
        gridRect.sizeDelta = new Vector2(300, 350);

        GridLayoutGroup gridLayout = gridObj.GetComponent<GridLayoutGroup>();
        if (gridLayout == null) gridLayout = gridObj.AddComponent<GridLayoutGroup>();

        gridLayout.cellSize = new Vector2(80, 80);
        gridLayout.spacing = new Vector2(20, 20);
        gridLayout.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        gridLayout.constraintCount = 3;
        gridLayout.childAlignment = TextAnchor.MiddleCenter;

        // 3. Find and modify buttons
        List<Transform> buttons = new List<Transform>();
        foreach (Transform child in panelTransform)
        {
            if (child.name.StartsWith("Buton"))
            {
                buttons.Add(child);
            }
        }

        // Sort buttons by text value
        buttons = buttons.OrderBy(b => {
            TMP_Text t = b.GetComponentInChildren<TMP_Text>(true);
            if (t != null && int.TryParse(t.text, out int val)) return val;
            return 999;
        }).ToList();

        ColorUtility.TryParseHtmlString("#2C2C2E", out Color buttonColor);
        Sprite knobSprite = AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/Knob.psd");

        foreach (Transform btn in buttons)
        {
            btn.SetParent(gridTransform != null ? gridTransform : gridObj.transform, false);

            Image btnImage = btn.GetComponent<Image>();
            if (btnImage != null)
            {
                btnImage.color = buttonColor;
                btnImage.sprite = knobSprite;
                btnImage.type = Image.Type.Sliced;
            }

            TMP_Text text = btn.GetComponentInChildren<TMP_Text>(true);
            if (text != null)
            {
                text.color = Color.white;
                text.fontStyle = FontStyles.Bold;
                text.fontSize = 36;
            }
        }

        // Adjust EkranYazisi (Screen Text)
        Transform ekranYazisi = panelTransform.Find("EkranYazisi");
        if (ekranYazisi != null)
        {
            RectTransform ekranRect = ekranYazisi.GetComponent<RectTransform>();
            if (ekranRect != null)
            {
                ekranRect.anchorMin = new Vector2(0.5f, 1f);
                ekranRect.anchorMax = new Vector2(0.5f, 1f);
                ekranRect.pivot = new Vector2(0.5f, 1f);
                ekranRect.anchoredPosition = new Vector2(0, -30); // 30 units from top
                ekranRect.sizeDelta = new Vector2(300, 60);
            }
        }

        EditorUtility.SetDirty(panel);
    }
}