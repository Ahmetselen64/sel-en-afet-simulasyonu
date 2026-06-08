using UnityEngine;
using UnityEditor;

public class CheckTags
{
    public static void Execute()
    {
        GameObject[] dropZones = GameObject.FindGameObjectsWithTag("ItemDropZone");
        foreach (GameObject go in dropZones)
        {
            Debug.Log("DropZone: " + go.name);
        }
    }
}
