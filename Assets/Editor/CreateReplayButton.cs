using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro;

public class CreateReplayButton
{
    public static void Execute()
    {
        GameObject canvas = GameObject.Find("Canvas");
        if (canvas == null)
        {
            Debug.LogError("Canvas not found");
            return;
        }

        GameObject exitButton = GameObject.Find("Canvas/ExitButton");
        if (exitButton == null)
        {
            Debug.LogError("ExitButton not found");
            return;
        }

        GameObject replayButton = Object.Instantiate(exitButton, canvas.transform);
        replayButton.name = "ReplayButton";

        RectTransform replayRect = replayButton.GetComponent<RectTransform>();
        replayRect.anchoredPosition = new Vector2(-100, -200);

        RectTransform exitRect = exitButton.GetComponent<RectTransform>();
        exitRect.anchoredPosition = new Vector2(100, -200);

        TextMeshProUGUI textComponent = replayButton.GetComponentInChildren<TextMeshProUGUI>();
        if (textComponent != null)
        {
            textComponent.text = "Tekrar Oyna";
        }

        LeaderboardManager manager = Object.FindAnyObjectByType<LeaderboardManager>();
        if (manager != null)
        {
            manager.replayButton = replayButton.GetComponent<Button>();
            EditorUtility.SetDirty(manager);
        }

        UnityEditor.SceneManagement.EditorSceneManager.MarkSceneDirty(UnityEditor.SceneManagement.EditorSceneManager.GetActiveScene());
        Debug.Log("ReplayButton created and assigned successfully.");
    }
}
