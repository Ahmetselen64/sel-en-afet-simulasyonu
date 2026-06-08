using UnityEngine;
using UnityEditor;

public class SetupFPS
{
    public static void Execute()
    {
        // Disable existing cameras
        Camera[] cameras = Object.FindObjectsByType<Camera>(FindObjectsSortMode.None);
        foreach (Camera cam in cameras)
        {
            cam.gameObject.SetActive(false);
        }

        // Create Player
        GameObject player = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        player.name = "Player";
        player.transform.position = new Vector3(0, 1, 0); // slightly above ground

        // Add components
        FPSController fpsController = player.AddComponent<FPSController>();

        // Create Camera
        GameObject playerCameraObj = new GameObject("PlayerCamera");
        Camera playerCamera = playerCameraObj.AddComponent<Camera>();
        playerCameraObj.AddComponent<AudioListener>();
        
        playerCameraObj.transform.SetParent(player.transform);
        playerCameraObj.transform.localPosition = new Vector3(0, 0.6f, 0);
        playerCameraObj.transform.localRotation = Quaternion.identity;

        // Assign camera to script
        fpsController.playerCamera = playerCamera;

        // Tag as MainCamera
        playerCameraObj.tag = "MainCamera";
    }
}
