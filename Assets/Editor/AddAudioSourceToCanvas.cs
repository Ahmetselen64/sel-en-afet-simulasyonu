using UnityEngine;
using UnityEditor;

public class AddAudioSourceToCanvas
{
    public static void Execute()
    {
        GameObject canvas = GameObject.Find("Canvas");
        if (canvas != null)
        {
            if (canvas.GetComponent<AudioSource>() == null)
            {
                canvas.AddComponent<AudioSource>();
                Debug.Log("Added AudioSource to Canvas.");
            }
            else
            {
                Debug.Log("Canvas already has an AudioSource.");
            }
        }
        else
        {
            Debug.LogError("Canvas not found.");
        }
    }
}
