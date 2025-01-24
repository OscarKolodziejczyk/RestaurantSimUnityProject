using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServingPickup : MonoBehaviour
{
    public Dish dish;
    public Transform stoveTransform;
    void Pickup()
    {
        if (CounterManager.Instance.AddDishToCounter(dish)) 
        { 
            GameManager.Instance.setCanInteractTrue(stoveTransform.GetComponent<Interactable>());
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        Pickup();
    }
}
