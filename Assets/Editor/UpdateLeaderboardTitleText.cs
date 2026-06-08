using UnityEngine;
using UnityEditor;
using TMPro;

public class UpdateLeaderboardTitleText
{
    public static void Execute()
    {
        GameObject titleTextObj = GameObject.Find("Canvas/TitleText");
        if (titleTextObj != null)
        {
            TextMeshProUGUI tmp = titleTextObj.GetComponent<TextMeshProUGUI>();
            if (tmp != null)
            {
                tmp.text = "Sel-en Afet Simülasyonu";
                tmp.enableAutoSizing = true;
                tmp.fontSizeMin = 36;
                tmp.fontSizeMax = 80;
                
                RectTransform rectTransform = titleTextObj.GetComponent<RectTransform>();
                if (rectTransform != null)
                {
                    rectTransform.sizeDelta = new Vector2(800, 120);
                }
                
                EditorUtility.SetDirty(tmp);
                if (rectTransform != null) EditorUtility.SetDirty(rectTransform);
                
                Debug.Log("Leaderboard title text updated successfully.");
            }
            else
            {
                Debug.LogError("TextMeshProUGUI component not found on TitleText.");
            }
        }
        else
        {
            Debug.LogError("TitleText object not found.");
        }
    }
}
