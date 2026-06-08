using UnityEngine;
using TMPro;

public class SafeZoneTrigger : MonoBehaviour
{
    public TaskManager taskManager;
    public GameObject winTextObject;
    public bool isPlayerInSafeZone = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (taskManager != null && taskManager.isPowerCompleted && taskManager.is112Completed && taskManager.isItemCompleted)
            {
                taskManager.CompleteTaskSafeZone();
                
                if (winTextObject != null)
                {
                    winTextObject.SetActive(true);
                }

                GameManager gm = FindAnyObjectByType<GameManager>();
                if (gm != null)
                {
                    gm.WinGame();
                    if (gm.resultText != null)
                    {
                        gm.resultText.gameObject.SetActive(false);
                    }
                }

                Time.timeScale = 0f;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            isPlayerInSafeZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInSafeZone = false;
        }
    }
}
