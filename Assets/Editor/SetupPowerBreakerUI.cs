using UnityEngine;
using UnityEditor;
using TMPro;

public class SetupPowerBreakerUI
{
    [MenuItem("Tools/Setup Power Breaker UI")]
    public static void Setup()
    {
        // 1. Create TaskPowerText UI element
        GameObject taskPanel = GameObject.Find("TaskPanel");
        if (taskPanel == null)
        {
            Debug.LogError("TaskPanel not found!");
            return;
        }

        GameObject taskPowerTextObj = new GameObject("TaskPowerText");
        taskPowerTextObj.transform.SetParent(taskPanel.transform, false);
        
        TextMeshProUGUI taskPowerText = taskPowerTextObj.AddComponent<TextMeshProUGUI>();
        taskPowerText.text = "[ ] Elektrik salterini kapat.";
        taskPowerText.fontSize = 24;
        taskPowerText.color = Color.white;
        taskPowerText.alignment = TextAlignmentOptions.Left;
        
        RectTransform rectTransform = taskPowerText.GetComponent<RectTransform>();
        rectTransform.anchorMin = new Vector2(0, 1);
        rectTransform.anchorMax = new Vector2(1, 1);
        rectTransform.pivot = new Vector2(0.5f, 1);
        rectTransform.anchoredPosition = new Vector2(0, -100); // Adjust position below other tasks
        rectTransform.sizeDelta = new Vector2(0, 30);

        // 2. Assign TaskPowerText to TaskManager
        TaskManager taskManager = Object.FindAnyObjectByType<TaskManager>();
        if (taskManager != null)
        {
            taskManager.taskPower = taskPowerText;
            EditorUtility.SetDirty(taskManager);
        }
        else
        {
            Debug.LogError("TaskManager not found!");
        }

        // 3. Ensure Salter tag exists and is assigned to SalterKutusu
        SerializedObject tagManager = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset")[0]);
        SerializedProperty tagsProp = tagManager.FindProperty("tags");
        
        bool found = false;
        for (int i = 0; i < tagsProp.arraySize; i++)
        {
            SerializedProperty t = tagsProp.GetArrayElementAtIndex(i);
            if (t.stringValue.Equals("Salter")) { found = true; break; }
        }
        
        if (!found)
        {
            tagsProp.InsertArrayElementAtIndex(0);
            SerializedProperty n = tagsProp.GetArrayElementAtIndex(0);
            n.stringValue = "Salter";
            tagManager.ApplyModifiedProperties();
        }

        GameObject salterKutusu = GameObject.Find("SalterKutusu");
        if (salterKutusu != null)
        {
            salterKutusu.tag = "Salter";
            
            // Ensure it has a collider
            if (salterKutusu.GetComponent<Collider>() == null)
            {
                salterKutusu.AddComponent<BoxCollider>();
            }
            
            EditorUtility.SetDirty(salterKutusu);
        }
        else
        {
            Debug.LogError("SalterKutusu not found!");
        }

        Debug.Log("Power Breaker UI Setup Complete!");
    }
}
