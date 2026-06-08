using UnityEngine;
using UnityEditor;

public class HideOtherPanels
{
    public static void Execute()
    {
        GameObject canvas = GameObject.Find("Canvas");
        if (canvas != null)
        {
            Transform mainMenu = canvas.transform.Find("MainMenuPanel");
            if (mainMenu != null) mainMenu.gameObject.SetActive(false);
            
            Transform taskPanel = canvas.transform.Find("TaskPanel");
            if (taskPanel != null) taskPanel.gameObject.SetActive(false);
        }
    }
}