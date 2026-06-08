using UnityEngine;
using UnityEditor;

public class SetupItemDropZones
{
    public static void Execute()
    {
        GameObject[] dropZones = GameObject.FindGameObjectsWithTag("ItemDropZone");
        foreach (GameObject go in dropZones)
        {
            if (go.GetComponent<ItemDropZone>() == null)
            {
                go.AddComponent<ItemDropZone>();
                Debug.Log("Added ItemDropZone to " + go.name);
            }
        }
    }
}
