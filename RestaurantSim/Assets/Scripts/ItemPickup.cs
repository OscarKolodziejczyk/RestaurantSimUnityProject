using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;
    public Transform stoveTransform;

    void Pickup() {
        InventoryManager.Instance.Add(item);
        GameManager.Instance.setCanInteractTrue(stoveTransform.GetComponent<Interactable>());
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        Pickup();
    }
}
