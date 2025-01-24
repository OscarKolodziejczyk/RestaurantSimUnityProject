using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveInteractor : MonoBehaviour
{
    public Interactable interactable;
    public StoveUI stoveUI;
    private void OnMouseDown()
    {
        if (interactable.colliding && interactable.canInteract)
        {
            UIManager.Instance.AddUI(stoveUI.gameObject);
            
            stoveUI.stoveTransform = transform;
        }
    }
}
