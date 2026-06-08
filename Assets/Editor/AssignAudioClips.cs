using UnityEngine;
using UnityEditor;

public class AssignAudioClips
{
    public static void Execute()
    {
        GameObject canvas = GameObject.Find("Canvas");
        if (canvas != null)
        {
            GameManager gm = canvas.GetComponent<GameManager>();
            if (gm != null)
            {
                AudioClip winClip = AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/musicbyell-level-up-373892.mp3");
                AudioClip loseClip = AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/moonwalk1-game-over-8-bit-chiptune-164330.mp3");
                
                gm.winSound = winClip;
                gm.loseSound = loseClip;
                
                EditorUtility.SetDirty(gm);
                Debug.Log("Assigned audio clips to GameManager.");
            }
        }
    }
}
