using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.Events;

public class FixLosePanel
{
    public static void Execute()
    {
        GameObject canvas = GameObject.Find("Canvas");
        if (canvas == null)
        {
            Debug.LogError("Canvas not found");
            return;
        }

        Transform losePanelTransform = canvas.transform.Find("LosePanel");
        if (losePanelTransform == null)
        {
            Debug.LogError("LosePanel not found");
            return;
        }

        GameObject losePanel = losePanelTransform.gameObject;

        // Attach LosePanelController
        LosePanelController controller = losePanel.GetComponent<LosePanelController>();
        if (controller == null)
        {
            controller = losePanel.AddComponent<LosePanelController>();
        }

        // Fix Layout
        Transform replayBtnTransform = losePanel.transform.Find("LoseReplayButton");
        if (replayBtnTransform != null)
        {
            RectTransform rect = replayBtnTransform.GetComponent<RectTransform>();
            rect.anchoredPosition = new Vector2(-100, -80); // Move left and down
            
            Button btn = replayBtnTransform.GetComponent<Button>();
            btn.onClick.RemoveAllListeners();
            UnityEditor.Events.UnityEventTools.AddPersistentListener(btn.onClick, new UnityAction(controller.RestartGame));
        }

        Transform exitBtnTransform = losePanel.transform.Find("LoseExitButton");
        if (exitBtnTransform != null)
        {
            RectTransform rect = exitBtnTransform.GetComponent<RectTransform>();
            rect.anchoredPosition = new Vector2(100, -80); // Move right and down
            
            Button btn = exitBtnTransform.GetComponent<Button>();
            btn.onClick.RemoveAllListeners();
            UnityEditor.Events.UnityEventTools.AddPersistentListener(btn.onClick, new UnityAction(controller.QuitGame));
        }

        EditorUtility.SetDirty(losePanel);
        UnityEditor.SceneManagement.EditorSceneManager.MarkSceneDirty(UnityEditor.SceneManagement.EditorSceneManager.GetActiveScene());
        Debug.Log("LosePanel fixed successfully.");
    }
}
