using UnityEngine;
using TMPro;

public class TaskManager : MonoBehaviour
{
    public TextMeshProUGUI task112;
    public TextMeshProUGUI taskItem;
    public TextMeshProUGUI taskPower;
    public TextMeshProUGUI taskSafeZone;

    public bool isPowerCompleted = false;
    public bool is112Completed = false;
    public bool isItemCompleted = false;

    public void CompleteTaskPower()
    {
        if (taskPower != null)
        {
            taskPower.text = "[✔] Elektrik salterini kapat.";
            taskPower.color = Color.green;
            isPowerCompleted = true;
        }
    }

    public void CompleteTask112()
    {
        if (task112 != null)
        {
            task112.text = "[✔] 112'yi ara ve bilgi ver.";
            task112.color = Color.green;
            is112Completed = true;
        }
    }

    public void CompleteTaskItem()
    {
        if (taskItem != null)
        {
            taskItem.text = "[✔] Kritik esyalari kurtar.";
            taskItem.color = Color.green;
            isItemCompleted = true;
        }
    }

    public void CompleteTaskSafeZone()
    {
        if (taskSafeZone != null)
        {
            taskSafeZone.text = "[✔] Yatağın üzerine çıkıp kendini güvene al.";
            taskSafeZone.color = Color.green;
        }
    }
}
