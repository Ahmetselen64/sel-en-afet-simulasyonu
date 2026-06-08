using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class SetupPhoneSystem : MonoBehaviour
{
    [MenuItem("Tools/Setup Phone System")]
    public static void Setup()
    {
        GameObject evTelefonu = GameObject.Find("EvTelefonu");
        if (evTelefonu == null)
        {
            Debug.LogError("EvTelefonu not found!");
            return;
        }

        PhoneSystem phoneSystem = evTelefonu.GetComponent<PhoneSystem>();
        if (phoneSystem == null)
        {
            phoneSystem = evTelefonu.AddComponent<PhoneSystem>();
        }

        GameObject telefonPaneli = GameObject.Find("Canvas/TelefonPaneli");
        if (telefonPaneli == null)
        {
            Debug.LogError("TelefonPaneli not found!");
            return;
        }

        phoneSystem.phoneUIPanel = telefonPaneli;

        Transform ekranYazisi = telefonPaneli.transform.Find("EkranYazisi");
        if (ekranYazisi != null)
        {
            phoneSystem.screenText = ekranYazisi.GetComponent<TextMeshProUGUI>();
        }

        // Setup buttons
        Button[] buttons = telefonPaneli.GetComponentsInChildren<Button>(true);
        foreach (Button btn in buttons)
        {
            TextMeshProUGUI btnText = btn.GetComponentInChildren<TextMeshProUGUI>();
            if (btnText != null)
            {
                string number = btnText.text;
                
                // Clear existing persistent listeners
                while (btn.onClick.GetPersistentEventCount() > 0)
                {
                    UnityEditor.Events.UnityEventTools.RemovePersistentListener(btn.onClick, 0);
                }

                // Add new persistent listener
                UnityAction<string> action = new UnityAction<string>(phoneSystem.PressNumber);
                UnityEditor.Events.UnityEventTools.AddStringPersistentListener(btn.onClick, action, number);
            }
        }

        EditorUtility.SetDirty(evTelefonu);
        EditorUtility.SetDirty(telefonPaneli);
        
        // Hide panel by default
        telefonPaneli.SetActive(false);

        Debug.Log("Phone System Setup Complete!");
    }
}
