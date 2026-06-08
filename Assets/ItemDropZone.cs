using UnityEngine;
using System.Collections.Generic;

public class ItemDropZone : MonoBehaviour
{
    public List<Transform> itemsInZone = new List<Transform>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            if (!itemsInZone.Contains(other.transform))
            {
                itemsInZone.Add(other.transform);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            if (itemsInZone.Contains(other.transform))
            {
                itemsInZone.Remove(other.transform);
            }
        }
    }
}
