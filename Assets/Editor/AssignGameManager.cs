using UnityEngine;
using UnityEditor;
using TMPro;

public class AssignGameManager
{
    public static void Execute()
    {
        GameObject canvas = GameObject.Find("Canvas");
        if (canvas != null)
        {
            GameManager gm = canvas.GetComponent<GameManager>();
            if (gm == null)
            {
                gm = canvas.AddComponent<GameManager>();
            }
            
            GameObject sonucYazisi = GameObject.Find("Canvas/SonucYazisi");
            if (sonucYazisi != null)
            {
                gm.resultText = sonucYazisi.GetComponent<TextMeshProUGUI>();
            }
            
            GameObject selSuyu = GameObject.Find("SelSuyu");
            if (selSuyu != null)
            {
                gm.waterTransform = selSuyu.transform;
            }
            
            GameObject ilacKutusu = GameObject.Find("IlacKutusu");
            GameObject tapuDosyasi = GameObject.Find("TapuDosyasi");
            GameObject laptop = GameObject.Find("Laptop");
            
            gm.itemsList = new Transform[3];
            if (ilacKutusu != null) gm.itemsList[0] = ilacKutusu.transform;
            if (tapuDosyasi != null) gm.itemsList[1] = tapuDosyasi.transform;
            if (laptop != null) gm.itemsList[2] = laptop.transform;
            
            EditorUtility.SetDirty(canvas);
        }
    }
}
