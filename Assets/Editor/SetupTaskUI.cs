using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro;

public class SetupTaskUI
{
    [MenuItem("Tools/Setup Task UI")]
    public static void Setup()
    {
        Canvas canvas = Object.FindAnyObjectByType<Canvas>();
        if (canvas == null)
        {
            Debug.LogError("No Canvas found in the scene.");
            return;
        }

        // Create TaskPanel
        GameObject taskPanelObj = new GameObject("TaskPanel");
        taskPanelObj.transform.SetParent(canvas.transform, false);
        RectTransform panelRect = taskPanelObj.AddComponent<RectTransform>();
        
        // Anchor Top-Left
        panelRect.anchorMin = new Vector2(0, 1);
        panelRect.anchorMax = new Vector2(0, 1);
        panelRect.pivot = new Vector2(0, 1);
        panelRect.anchoredPosition = new Vector2(20, -20); // slight offset
        panelRect.sizeDelta = new Vector2(300, 200);

        Image panelImage = taskPanelObj.AddComponent<Image>();
        panelImage.color = new Color(0, 0, 0, 0.5f); // semi-transparent black

        // Create TitleText
        GameObject titleObj = new GameObject("TitleText");
        titleObj.transform.SetParent(taskPanelObj.transform, false);
        RectTransform titleRect = titleObj.AddComponent<RectTransform>();
        titleRect.anchorMin = new Vector2(0, 1);
        titleRect.anchorMax = new Vector2(1, 1);
        titleRect.pivot = new Vector2(0.5f, 1);
        titleRect.anchoredPosition = new Vector2(0, -10);
        titleRect.sizeDelta = new Vector2(0, 40);

        TextMeshProUGUI titleText = titleObj.AddComponent<TextMeshProUGUI>();
        titleText.text = "YAPILACAKLAR";
        titleText.color = Color.yellow;
        titleText.alignment = TextAlignmentOptions.Top;
        titleText.fontSize = 24;
        titleText.fontStyle = FontStyles.Bold;

        // Create Task112Text
        GameObject task112Obj = new GameObject("Task112Text");
        task112Obj.transform.SetParent(taskPanelObj.transform, false);
        RectTransform task112Rect = task112Obj.AddComponent<RectTransform>();
        task112Rect.anchorMin = new Vector2(0, 1);
        task112Rect.anchorMax = new Vector2(1, 1);
        task112Rect.pivot = new Vector2(0.5f, 1);
        task112Rect.anchoredPosition = new Vector2(10, -60);
        task112Rect.sizeDelta = new Vector2(-20, 30);

        TextMeshProUGUI task112Text = task112Obj.AddComponent<TextMeshProUGUI>();
        task112Text.text = "[ ] 112'yi ara ve bilgi ver.";
        task112Text.color = Color.white;
        task112Text.alignment = TextAlignmentOptions.Left;
        task112Text.fontSize = 18;

        // Create TaskItemText
        GameObject taskItemObj = new GameObject("TaskItemText");
        taskItemObj.transform.SetParent(taskPanelObj.transform, false);
        RectTransform taskItemRect = taskItemObj.AddComponent<RectTransform>();
        taskItemRect.anchorMin = new Vector2(0, 1);
        taskItemRect.anchorMax = new Vector2(1, 1);
        taskItemRect.pivot = new Vector2(0.5f, 1);
        taskItemRect.anchoredPosition = new Vector2(10, -100);
        taskItemRect.sizeDelta = new Vector2(-20, 30);

        TextMeshProUGUI taskItemText = taskItemObj.AddComponent<TextMeshProUGUI>();
        taskItemText.text = "[ ] Kritik esyalari kurtar.";
        taskItemText.color = Color.white;
        taskItemText.alignment = TextAlignmentOptions.Left;
        taskItemText.fontSize = 18;

        // Attach TaskManager to Canvas
        TaskManager taskManager = canvas.gameObject.GetComponent<TaskManager>();
        if (taskManager == null)
        {
            taskManager = canvas.gameObject.AddComponent<TaskManager>();
        }
        
        taskManager.task112 = task112Text;
        taskManager.taskItem = taskItemText;

        UnityEditor.SceneManagement.EditorSceneManager.MarkSceneDirty(UnityEditor.SceneManagement.EditorSceneManager.GetActiveScene());
        Debug.Log("Task UI Setup Complete");
    }
}
