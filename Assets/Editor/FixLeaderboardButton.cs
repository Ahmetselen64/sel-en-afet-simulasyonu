using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class FixLeaderboardButton
{
    public static void Execute()
    {
        GameObject buttonObj = GameObject.Find("Canvas/WinPanel/LeaderboardButton");
        if (buttonObj != null)
        {
            Button button = buttonObj.GetComponent<Button>();
            Image image = buttonObj.GetComponent<Image>();
            if (button != null && image != null)
            {
                button.targetGraphic = image;
                EditorUtility.SetDirty(buttonObj);
                Debug.Log("Fixed targetGraphic");
            }
        }
    }
}
