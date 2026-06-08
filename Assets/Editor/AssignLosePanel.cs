using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class AssignLosePanel
{
    public static void Execute()
    {
        GameManager gm = Object.FindAnyObjectByType<GameManager>();
        if (gm != null)
        {
            GameObject canvas = GameObject.Find("Canvas");
            if (canvas != null)
            {
                Transform losePanelTransform = canvas.transform.Find("LosePanel");
                if (losePanelTransform != null)
                {
                    GameObject losePanel = losePanelTransform.gameObject;
                    gm.losePanel = losePanel;
                    
                    Transform replayBtn = losePanel.transform.Find("LoseReplayButton");
                    if (replayBtn != null)
                    {
                        gm.loseReplayButton = replayBtn.GetComponent<Button>();
                    }
                    
                    Transform exitBtn = losePanel.transform.Find("LoseExitButton");
                    if (exitBtn != null)
                    {
                        gm.loseExitButton = exitBtn.GetComponent<Button>();
                    }
                    
                    EditorUtility.SetDirty(gm);
                    UnityEditor.SceneManagement.EditorSceneManager.MarkSceneDirty(UnityEditor.SceneManagement.EditorSceneManager.GetActiveScene());
                    Debug.Log("Assigned LosePanel and buttons to GameManager.");
                }
                else
                {
                    Debug.LogError("LosePanel not found under Canvas.");
                }
            }
            else
            {
                Debug.LogError("Canvas not found.");
            }
        }
        else
        {
            Debug.LogError("GameManager not found.");
        }
    }
}
