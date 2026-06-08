using UnityEngine;
using UnityEditor;

public class ActivatePhonePanel
{
    public static void Execute()
    {
        GameObject canvas = GameObject.Find("Canvas");
        if (canvas != null)
        {
            Transform panelTransform = canvas.transform.Find("TelefonPaneli");
            if (panelTransform != null)
            {
                panelTransform.gameObject.SetActive(true);
            }
        }
    }
}