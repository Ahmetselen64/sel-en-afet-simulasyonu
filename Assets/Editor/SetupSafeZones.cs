using UnityEngine;
using UnityEditor;

public class SetupSafeZones
{
    public static void Execute()
    {
        GameObject safe1 = GameObject.Find("Safe ");
        GameObject safe2 = GameObject.Find("Safe  (1)");

        if (safe1 == null) Debug.LogError("Safe not found");
        if (safe2 == null) Debug.LogError("Safe (1) not found");

        // Create Material
        Shader shader = Shader.Find("Universal Render Pipeline/Lit");
        if (shader == null) shader = Shader.Find("Standard");
        
        Material mat = new Material(shader);
        
        // Set transparent
        mat.SetFloat("_Surface", 1); // 1 = Transparent
        mat.SetFloat("_Blend", 0); // 0 = Alpha
        mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        mat.SetInt("_ZWrite", 0);
        mat.EnableKeyword("_SURFACE_TYPE_TRANSPARENT");
        mat.renderQueue = (int)UnityEngine.Rendering.RenderQueue.Transparent;
        
        mat.SetColor("_BaseColor", new Color(0, 1, 0, 0.4f));
        mat.SetColor("_Color", new Color(0, 1, 0, 0.4f)); // Fallback for Standard

        if (!AssetDatabase.IsValidFolder("Assets/Materials"))
        {
            AssetDatabase.CreateFolder("Assets", "Materials");
        }
        
        AssetDatabase.CreateAsset(mat, "Assets/Materials/Green_Placement_Hint.mat");
        AssetDatabase.SaveAssets();

        Mesh cubeMesh = null;
        GameObject temp = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cubeMesh = temp.GetComponent<MeshFilter>().sharedMesh;
        GameObject.DestroyImmediate(temp);

        SetupObject(safe1, cubeMesh, mat);
        SetupObject(safe2, cubeMesh, mat);
    }

    private static void SetupObject(GameObject go, Mesh mesh, Material mat)
    {
        if (go == null) return;

        MeshFilter mf = go.GetComponent<MeshFilter>();
        if (mf == null) mf = go.AddComponent<MeshFilter>();
        mf.sharedMesh = mesh;

        MeshRenderer mr = go.GetComponent<MeshRenderer>();
        if (mr == null) mr = go.AddComponent<MeshRenderer>();
        mr.sharedMaterial = mat;
    }
}