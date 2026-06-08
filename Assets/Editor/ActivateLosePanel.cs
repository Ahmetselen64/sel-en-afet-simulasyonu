using UnityEngine;
using UnityEditor;

public class ActivateLosePanel
{
    public static void Execute()
    {
        GameObject canvas = GameObject.Find("Canvas");
        if (canvas != null)
        {
            Transform losePanelTransform = canvas.transform.Find("LosePanel");
            if (losePanelTransform != null)
            {
                losePanelTransform.gameObject.SetActive(true);
                Debug.Log("LosePanel activated.");
            }
        }
    }
}
