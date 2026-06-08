using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaderboardButton : MonoBehaviour
{
    public void OnLeaderboardButtonClicked()
    {
        float actualRemainingTime = 0f;
        FloodController floodController = FindAnyObjectByType<FloodController>();
        if (floodController != null)
        {
            actualRemainingTime = floodController.countdownTime;
            if (actualRemainingTime < 0f) actualRemainingTime = 0f;
        }

        PlayerPrefs.SetFloat("SavedTime", actualRemainingTime);
        PlayerPrefs.Save();
        SceneManager.LoadScene("LeaderboardScene");
    }
}
