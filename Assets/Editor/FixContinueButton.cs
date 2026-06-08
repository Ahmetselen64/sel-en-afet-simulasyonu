using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class FixContinueButton
{
    public static void Execute()
    {
        GameObject buttonObj = GameObject.Find("Canvas/NewsPanel/ContinueButton");
        if (buttonObj == null)
        {
            // Try finding inactive
            Transform canvas = GameObject.Find("Canvas").transform;
            Transform newsPanel = canvas.Find("NewsPanel");
            if (newsPanel != null)
            {
                Transform btn = newsPanel.Find("ContinueButton");
                if (btn != null)
                {
                    buttonObj = btn.gameObject;
                }
            }
        }

        if (buttonObj != null)
        {
            Button button = buttonObj.GetComponent<Button>();
            if (button != null)
            {
                // Clear existing listeners
                while (button.onClick.GetPersistentEventCount() > 0)
                {
                    UnityEditor.Events.UnityEventTools.RemovePersistentListener(button.onClick, 0);
                }

                GameObject canvasObj = GameObject.Find("Canvas");
                if (canvasObj != null)
                {
                    MainMenuManager manager = canvasObj.GetComponent<MainMenuManager>();
                    if (manager != null)
                    {
                        UnityAction action = new UnityAction(manager.ConfirmNews);
                        UnityEditor.Events.UnityEventTools.AddPersistentListener(button.onClick, action);
                        Debug.Log("Successfully fixed ContinueButton.");
                    }
                    else
                    {
                        Debug.LogError("MainMenuManager not found on Canvas.");
                    }
                }
                else
                {
                    Debug.LogError("Canvas not found.");
                }
            }
            else
            {
                Debug.LogError("Button component not found on ContinueButton.");
            }
        }
        else
        {
            Debug.LogError("ContinueButton not found.");
        }
    }
}
