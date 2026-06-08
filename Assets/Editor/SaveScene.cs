using UnityEditor;
using UnityEditor.SceneManagement;

public class SaveScene
{
    public static void Execute()
    {
        EditorSceneManager.SaveScene(EditorSceneManager.GetActiveScene());
    }
}