using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class CheckPhonePanel
{
    public static void Execute()
    {
        GameObject canvas = GameObject.Find("Canvas");
        if (canvas == null) {
            File.WriteAllText("Assets/Editor/PhoneButtons.txt", "Canvas not found");
            return;
        }
        Transform panelTransform = canvas.transform.Find("TelefonPaneli");
        if (panelTransform == null) {
            File.WriteAllText("Assets/Editor/PhoneButtons.txt", "TelefonPaneli not found");
            return;
        }
        GameObject panel = panelTransform.gameObject;
        string output = "";
        foreach (Transform child in panel.transform)
        {
            if (child.name.StartsWith("Buton"))
            {
                TMP_Text text = child.GetComponentInChildren<TMP_Text>(true);
                if (text != null)
                {
                    output += child.name + " text: " + text.text + "\n";
                }
                else
                {
                    output += child.name + " text: NULL\n";
                }
            }
        }
        File.WriteAllText("Assets/Editor/PhoneButtons.txt", output);
    }
}