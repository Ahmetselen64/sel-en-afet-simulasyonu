using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public GameObject MainMenuPanel;
    public GameObject NewsPanel;
    private GameObject taskPanel;
    private FPSController fpsController;

    void Start()
    {
        if (MainMenuPanel != null)
        {
            MainMenuPanel.SetActive(true);
        }

        fpsController = FindObjectOfType<FPSController>();
        if (fpsController != null)
        {
            fpsController.enabled = false;
        }

        taskPanel = GameObject.Find("TaskPanel");
        if (taskPanel == null)
        {
            Transform tpTransform = transform.Find("TaskPanel");
            if (tpTransform != null)
            {
                taskPanel = tpTransform.gameObject;
            }
        }

        if (taskPanel != null)
        {
            taskPanel.SetActive(false);
        }

        if (NewsPanel != null)
        {
            NewsPanel.SetActive(false);
        }

        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void StartGame()
    {
        if (MainMenuPanel != null)
        {
            MainMenuPanel.SetActive(false);
        }

        if (NewsPanel != null)
        {
            NewsPanel.SetActive(true);
        }
    }

    public void ConfirmNews()
    {
        if (NewsPanel != null)
        {
            NewsPanel.SetActive(false);
        }

        if (fpsController != null)
        {
            fpsController.enabled = true;
        }

        if (taskPanel != null)
        {
            taskPanel.SetActive(true);
        }

        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
