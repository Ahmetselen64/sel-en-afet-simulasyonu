using UnityEngine;
using UnityEditor;
using TMPro;

public class FixTimerText
{
    public static void Execute()
    {
        GameObject timerTextObj = GameObject.Find("Canvas/ZamanlayiciYazisi");
        if (timerTextObj == null)
        {
            // Try to find it even if inactive
            Transform canvas = GameObject.Find("Canvas").transform;
            Transform timerTextTransform = canvas.Find("ZamanlayiciYazisi");
            if (timerTextTransform != null)
            {
                timerTextObj = timerTextTransform.gameObject;
            }
        }

        if (timerTextObj != null)
        {
            timerTextObj.SetActive(true);

            RectTransform rectTransform = timerTextObj.GetComponent<RectTransform>();
            if (rectTransform != null)
            {
                rectTransform.anchorMin = new Vector2(1, 1);
                rectTransform.anchorMax = new Vector2(1, 1);
                rectTransform.pivot = new Vector2(1, 1);
                rectTransform.anchoredPosition = new Vector2(-20, -20);
                rectTransform.sizeDelta = new Vector2(400, 60);
            }

            TextMeshProUGUI tmp = timerTextObj.GetComponent<TextMeshProUGUI>();
            if (tmp != null)
            {
                tmp.color = Color.white;
                tmp.fontSize = 40;
                tmp.alignment = TextAlignmentOptions.TopRight;
            }

            EditorUtility.SetDirty(timerTextObj);
            Debug.Log("Timer text fixed.");
        }
        else
        {
            Debug.LogError("Timer text not found.");
        }
    }
}
