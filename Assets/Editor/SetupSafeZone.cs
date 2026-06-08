using UnityEngine;
using UnityEditor;
using TMPro;

public class SetupSafeZone
{
    public static void Execute()
    {
        GameObject canvas = GameObject.Find("Canvas");
        if (canvas == null)
        {
            Debug.LogError("Canvas not found");
            return;
        }

        GameObject safeZone = GameObject.Find("SafeZone");
        if (safeZone == null)
        {
            Debug.LogError("SafeZone not found");
            return;
        }

        // Create WinText
        GameObject winTextObj = new GameObject("WinText");
        winTextObj.transform.SetParent(canvas.transform, false);
        
        TextMeshProUGUI winText = winTextObj.AddComponent<TextMeshProUGUI>();
        winText.text = "TEBRİKLER! GÜVENLİ BÖLGEYE ULAŞTIN! EKİPLER SENİ KURTARDI";
        winText.color = Color.green;
        winText.fontSize = 48;
        winText.alignment = TextAlignmentOptions.Center;
        winText.fontStyle = FontStyles.Bold;
        
        RectTransform rt = winText.GetComponent<RectTransform>();
        rt.anchorMin = new Vector2(0, 0);
        rt.anchorMax = new Vector2(1, 1);
        rt.offsetMin = Vector2.zero;
        rt.offsetMax = Vector2.zero;

        winTextObj.SetActive(false);

        // Setup SafeZoneTrigger
        SafeZoneTrigger trigger = safeZone.GetComponent<SafeZoneTrigger>();
        if (trigger == null)
        {
            trigger = safeZone.AddComponent<SafeZoneTrigger>();
        }

        TaskManager taskManager = canvas.GetComponent<TaskManager>();
        trigger.taskManager = taskManager;
        trigger.winTextObject = winTextObj;

        // Assign taskSafeZone to TaskManager
        GameObject taskSafeZoneObj = GameObject.Find("Canvas/TaskPanel/TaskItemText (1)");
        if (taskSafeZoneObj != null)
        {
            taskManager.taskSafeZone = taskSafeZoneObj.GetComponent<TextMeshProUGUI>();
        }
        else
        {
            Debug.LogError("TaskItemText (1) not found");
        }

        // Ensure SafeZone has a collider with isTrigger = true
        Collider col = safeZone.GetComponent<Collider>();
        if (col != null)
        {
            col.isTrigger = true;
        }
        else
        {
            BoxCollider box = safeZone.AddComponent<BoxCollider>();
            box.isTrigger = true;
        }

        Debug.Log("SafeZone setup complete");
    }
}
