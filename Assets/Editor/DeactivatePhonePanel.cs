using UnityEngine;
using UnityEditor;

public class DeactivatePhonePanel
{
    public static void Execute()
    {
        GameObject canvas = GameObject.Find("Canvas");
        if (canvas != null)
        {
            Transform panelTransform = canvas.transform.Find("TelefonPaneli");
            if (panelTransform != null)
            {
                panelTransform.gameObject.SetActive(false);
                EditorUtility.SetDirty(canvas);
            }
        }
    }
}