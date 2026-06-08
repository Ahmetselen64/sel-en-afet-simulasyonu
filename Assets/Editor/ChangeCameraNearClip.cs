using UnityEngine;
using UnityEditor;

public class ChangeCameraNearClip
{
    public static void Execute()
    {
        GameObject cameraObj = GameObject.Find("Player/Camera");
        if (cameraObj != null)
        {
            Camera cam = cameraObj.GetComponent<Camera>();
            if (cam != null)
            {
                cam.nearClipPlane = 0.01f;
                EditorUtility.SetDirty(cam);
                Debug.Log("Camera near clip plane set to 0.01");
            }
            else
            {
                Debug.LogError("Camera component not found on Player/Camera");
            }
        }
        else
        {
            Debug.LogError("Player/Camera not found");
        }
    }
}