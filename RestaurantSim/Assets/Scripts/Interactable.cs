using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Collider2D collider2d;
    public bool colliding = false;
    public bool canInteract = true;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // On collision, prompt the user with the option to open the stove.
        colliding = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        // On collision, prompt the user with the option to open the stove.
        colliding = false;
    }

    // While mouse hovers over an Interactable, display a clickable cursor.
    public void OnMouseEnter()
    {
        if (canInteract) 
            { 
                MouseController.Instance.Clickable();
            }
        // TODO: If hovering over for more than 1.5 seconds, popup a description box
    }
    public void OnMouseExit()
    {
        MouseController.Instance.Default();
    }

}
