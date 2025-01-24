using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroceryVendor : MonoBehaviour
{
    public Interactable interactable;
    public GameObject groceryUI;
    private void OnMouseDown()
    {
        if (interactable.colliding && interactable.canInteract)
        {
            UIManager.Instance.AddUI(groceryUI.gameObject);
        }
    }
}
