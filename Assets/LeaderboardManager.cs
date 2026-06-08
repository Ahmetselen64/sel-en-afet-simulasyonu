using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LeaderboardManager : MonoBehaviour
{
    public TMP_InputField nameInput;
    public Button saveButton;
    public TextMeshProUGUI leaderboardText;
    public Button exitButton;
    public Button replayButton;

    private void Start()
    {
        if (saveButton != null)
        {
            saveButton.onClick.AddListener(SaveScore);
        }
        if (exitButton != null)
        {
            exitButton.onClick.AddListener(ExitGame);
        }
        if (replayButton != null)
        {
            replayButton.onClick.AddListener(ReplayGame);
        }
        UpdateLeaderboardDisplay();
    }

    private void ReplayGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Demo");
    }

    private void ExitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    private void SaveScore()
    {
        string playerName = nameInput != null ? nameInput.text : "Unknown";
        if (string.IsNullOrEmpty(playerName))
        {
            playerName = "Unknown";
        }

        float savedTime = PlayerPrefs.GetFloat("SavedTime", 0f);
        int finalScore = 10 + (Mathf.RoundToInt(savedTime) * 10);

        string allScores = PlayerPrefs.GetString("AllScores", "");
        allScores += $"isim: {playerName} - Skor: {finalScore}\n";

        PlayerPrefs.SetString("AllScores", allScores);
        PlayerPrefs.Save();

        UpdateLeaderboardDisplay();
    }

    private void UpdateLeaderboardDisplay()
    {
        string allScores = PlayerPrefs.GetString("AllScores", "");

        if (leaderboardText != null)
        {
            if (!string.IsNullOrEmpty(allScores))
            {
                leaderboardText.text = allScores;
            }
            else
            {
                leaderboardText.text = "No scores yet.";
            }
        }
    }
}
