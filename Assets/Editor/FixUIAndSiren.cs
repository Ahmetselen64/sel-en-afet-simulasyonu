using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEditor.Events;

public class FixUIAndSiren
{
    public static void Execute()
    {
        GameObject canvas = GameObject.Find("Canvas");
        if (canvas == null)
        {
            Debug.LogError("Canvas not found!");
            return;
        }

        Transform startButtonTransform = canvas.transform.Find("MainMenuPanel/StartButton");
        Transform continueButtonTransform = canvas.transform.Find("NewsPanel/ContinueButton");
        Transform newsPanelTransform = canvas.transform.Find("NewsPanel");

        if (startButtonTransform != null)
        {
            Button startButton = startButtonTransform.GetComponent<Button>();
            if (startButton != null)
            {
                int eventCount = startButton.onClick.GetPersistentEventCount();
                for (int i = eventCount - 1; i >= 0; i--)
                {
                    Object target = startButton.onClick.GetPersistentTarget(i);
                    if (target is AudioSource)
                    {
                        UnityEventTools.RemovePersistentListener(startButton.onClick, i);
                    }
                }
                
                AudioSource audioSource = startButtonTransform.GetComponent<AudioSource>();
                if (audioSource != null)
                {
                    Object.DestroyImmediate(audioSource);
                }
            }
        }

        if (continueButtonTransform != null)
        {
            Button continueButton = continueButtonTransform.GetComponent<Button>();
            if (continueButton != null)
            {
                int eventCount = continueButton.onClick.GetPersistentEventCount();
                for (int i = eventCount - 1; i >= 0; i--)
                {
                    Object target = continueButton.onClick.GetPersistentTarget(i);
                    if (target is AudioSource)
                    {
                        UnityEventTools.RemovePersistentListener(continueButton.onClick, i);
                    }
                }

                AudioSource audioSource = continueButtonTransform.GetComponent<AudioSource>();
                if (audioSource != null)
                {
                    Object.DestroyImmediate(audioSource);
                }
            }
        }

        if (newsPanelTransform != null)
        {
            GameObject newsPanelObj = newsPanelTransform.gameObject;
            AudioSource newsAudio = newsPanelObj.GetComponent<AudioSource>();
            if (newsAudio == null)
            {
                newsAudio = newsPanelObj.AddComponent<AudioSource>();
            }

            AudioClip clip = AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/gabbynunez-new-york-usa-eas-alarm-503987.mp3");
            if (clip != null)
            {
                newsAudio.clip = clip;
            }
            else
            {
                Debug.LogError("AudioClip not found!");
            }

            newsAudio.playOnAwake = true;
            newsAudio.loop = true;
        }
        
        UnityEditor.SceneManagement.EditorSceneManager.MarkSceneDirty(UnityEditor.SceneManagement.EditorSceneManager.GetActiveScene());
    }
}