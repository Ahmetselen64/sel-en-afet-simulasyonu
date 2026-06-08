using UnityEngine;
using UnityEditor;
using TMPro;

public class UpdateTitleText
{
    public static void Execute()
    {
        GameObject titleTextObj = GameObject.Find("Canvas/MainMenuPanel/GameTitleText");
        if (titleTextObj != null)
        {
            TextMeshProUGUI tmp = titleTextObj.GetComponent<TextMeshProUGUI>();
            if (tmp != null)
            {
                tmp.text = "Sel-en Afet Simülasyonu";
                tmp.fontStyle = FontStyles.Bold;
                tmp.fontSize = 80; // Make it slightly larger to ensure prominence
                EditorUtility.SetDirty(tmp);
                Debug.Log("Title text updated successfully.");
            }
            else
            {
                Debug.LogError("TextMeshProUGUI component not found on GameTitleText.");
            }
        }
        else
        {
            Debug.LogError("GameTitleText object not found.");
        }
    }
}
