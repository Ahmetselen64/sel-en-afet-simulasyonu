using UnityEngine;
using TMPro;

[RequireComponent(typeof(AudioSource))]
public class GameManager : MonoBehaviour
{
    public AudioClip winSound;
    public AudioClip loseSound;
    private AudioSource audioSource;

    public TextMeshProUGUI resultText;
    public GameObject losePanel;
    public UnityEngine.UI.Button loseReplayButton;
    public UnityEngine.UI.Button loseExitButton;
    public Transform waterTransform;
    public Transform[] itemsList;
    
    public float winningHeight = 1.6f;
    public float maxWaterHeight = 1.5f;
    public bool isPowerOff = false;

    private bool gameEnded = false;
    private SafeZoneTrigger safeZoneTrigger;

    void Start()
    {
        safeZoneTrigger = FindAnyObjectByType<SafeZoneTrigger>();
        audioSource = GetComponent<AudioSource>();
        audioSource.ignoreListenerPause = true;

        if (loseReplayButton != null)
        {
            loseReplayButton.onClick.AddListener(ReplayGame);
        }
        if (loseExitButton != null)
        {
            loseExitButton.onClick.AddListener(ExitGame);
        }
        if (losePanel != null)
        {
            losePanel.SetActive(false);
        }
    }

    private void ReplayGame()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Demo");
    }

    private void ExitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    void Update()
    {
        if (gameEnded) return;

        if (waterTransform != null && waterTransform.position.y > 0.5f && !isPowerOff)
        {
            if (resultText != null)
            {
                resultText.text = "KAYBETTİN!\nSular prize ulaştı, Şalteri kapatmalıydın.";
                resultText.color = Color.red;
                resultText.fontSize = 30;
                resultText.alignment = TextAlignmentOptions.Center;
            }
            EndGame();
            return;
        }

        if (waterTransform != null && waterTransform.position.y >= maxWaterHeight - 0.01f)
        {
            bool inSafeZone = safeZoneTrigger != null && safeZoneTrigger.isPlayerInSafeZone;
            if (!inSafeZone)
            {
                if (resultText != null)
                {
                    resultText.text = "KAYBETTİN! Sular boyunu aştı, !";
                    resultText.color = Color.red;
                    resultText.fontSize = 30;
                    resultText.alignment = TextAlignmentOptions.Center;
                }
                EndGame();
                return;
            }
        }

        if (waterTransform != null && itemsList != null && itemsList.Length > 0 && resultText != null)
        {
            bool anyItemLost = false;

            foreach (Transform item in itemsList)
            {
                if (item != null)
                {
                    if (item.position.y < waterTransform.position.y)
                    {
                        anyItemLost = true;
                    }
                }
            }

            if (anyItemLost)
            {
                resultText.text = "KAYBETTİN!\nEşyalar sular altında kaldı.";
                resultText.color = Color.red;
                resultText.fontSize = 30;
                resultText.alignment = TextAlignmentOptions.Center;
                EndGame();
            }
            else
            {
                // Check if all items are in drop zones
                ItemDropZone[] dropZones = FindObjectsByType<ItemDropZone>(FindObjectsSortMode.None);
                bool allItemsInZones = true;

                foreach (Transform item in itemsList)
                {
                    if (item != null)
                    {
                        bool itemInAnyZone = false;
                        foreach (ItemDropZone zone in dropZones)
                        {
                            if (zone.itemsInZone.Contains(item))
                            {
                                itemInAnyZone = true;
                                break;
                            }
                        }

                        if (!itemInAnyZone)
                        {
                            allItemsInZones = false;
                            break;
                        }
                    }
                }

                if (allItemsInZones)
                {
                    TaskManager tm = FindAnyObjectByType<TaskManager>();
                    if (tm != null && !tm.isItemCompleted)
                    {
                        tm.CompleteTaskItem();
                    }
                }
            }
        }
    }

    public void WinGame()
    {
        if (gameEnded) return;
        gameEnded = true;
        if (audioSource != null && winSound != null)
        {
            audioSource.PlayOneShot(winSound);
        }
    }

    private void EndGame()
    {
        gameEnded = true;
        if (audioSource != null && loseSound != null)
        {
            audioSource.PlayOneShot(loseSound);
        }
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (losePanel != null)
        {
            losePanel.SetActive(true);
        }

        // Disable other UI texts to prevent overlap
        if (safeZoneTrigger != null && safeZoneTrigger.winTextObject != null)
        {
            safeZoneTrigger.winTextObject.SetActive(false);
        }
    }
}
