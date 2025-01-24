using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Serving : MonoBehaviour
{
    public GameObject counter;
    public Dish dish;
    public GameObject servingInfoUI;
    private int _servings;

    public int servings 
    {
        get { return _servings; }
        set
        {
            _servings = value;
            UpdateServingInfo();
        }
    }


    public void InitiateServing()
    {
        servings = dish.servingCount;
        gameObject.GetComponent<SpriteRenderer>().sprite = dish.finishedSprite;
        UpdateServingInfo();

    }

    public void DeleteDish()
    {
        servings = 0;
    }

    public void TakeAwayServing()
    {
        servings -= 1;
        CheckServingCount();
    }
    public void CheckServingCount()
    {
        if (servings <= 0)
        {
            counter.GetComponent<Counter>().hasDish = false;
            counter.GetComponent<Counter>().currDish = null;
            Destroy(gameObject);
        }
    }

    public void OnMouseEnter()
    {
        servingInfoUI.SetActive(true);
    }
    public void OnMouseExit()
    {
        servingInfoUI.SetActive(false);
    }

    public void UpdateServingInfo()
    {
        servingInfoUI.GetComponentInChildren<ServingInfoUI>().dishName = dish.dishName;
        servingInfoUI.GetComponentInChildren<ServingInfoUI>().servingCount = servings;
        servingInfoUI.GetComponentInChildren<ServingInfoUI>().UpdateText();
    }
}
