using UnityEngine;
using TMPro;

public class PhoneSystem : MonoBehaviour
{
    public GameObject phoneUIPanel;
    public TextMeshProUGUI screenText;

    private string currentNumber = "";
    private PlayerInteract playerInteract;

    void Start()
    {
        // Find PlayerInteract in the scene
        playerInteract = FindObjectOfType<PlayerInteract>();
    }

    public void OpenPhoneUI()
    {
        if (phoneUIPanel != null)
        {
            phoneUIPanel.SetActive(true);
        }
        
        if (playerInteract != null)
        {
            playerInteract.isUIOpen = true;
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void PressNumber(string number)
    {
        currentNumber += number;
        
        if (screenText != null)
        {
            screenText.text = currentNumber;
        }

        if (currentNumber == "112")
        {
            if (screenText != null)
            {
                screenText.text = "GÖREV BAŞARILI! 112 ARANDI EKİPLER YOLDA";
            }
            
            TaskManager taskManager = FindAnyObjectByType<TaskManager>();
            if (taskManager != null)
            {
                taskManager.CompleteTask112();
            }
            
            Invoke("ClosePhoneUI", 2f);
        }
        else if (currentNumber.Length >= 3)
        {
            currentNumber = "";
            if (screenText != null)
            {
                screenText.text = currentNumber;
            }
        }
    }

    private void ClosePhoneUI()
    {
        if (phoneUIPanel != null)
        {
            phoneUIPanel.SetActive(false);
        }

        if (playerInteract != null)
        {
            playerInteract.isUIOpen = false;
        }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        currentNumber = "";
        if (screenText != null)
        {
            screenText.text = currentNumber;
        }
    }
}
