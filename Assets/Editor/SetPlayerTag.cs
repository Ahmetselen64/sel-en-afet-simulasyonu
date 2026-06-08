using UnityEngine;
using UnityEditor;

public class SetPlayerTag
{
    public static void Execute()
    {
        GameObject player = GameObject.Find("Player");
        if (player != null)
        {
            player.tag = "Player";
            Debug.Log("Player tag set to Player");
        }
        else
        {
            Debug.LogError("Player not found");
        }
    }
}
