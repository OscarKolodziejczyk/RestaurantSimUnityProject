using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.ShaderKeywordFilter;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class Cook : MonoBehaviour
{
    //public Dish dish;
    public GameObject loadingBarPrefab;
    public Dish dish;
    public GameObject readyDish;
    public Canvas canvas;
    public StoveUI stoveUI;

    private Dictionary<Item, int> ingredientsDict = new Dictionary<Item, int>();

    public void CheckIngredients()
    {
        CreateIngredientsDict(dish.ingredientsList);
        
        foreach (Item ingredient in ingredientsDict.Keys) // for each ingrdt, check if inv has it, & that inv has >= # of ings needed
        {
            if (!InventoryManager.Instance.items.Keys.Contains(ingredient))
            {
                print("Missing Ingredients");
                EndCooking();
                return;
            }
            else if (InventoryManager.Instance.items[ingredient] < ingredientsDict[ingredient])
            {
                print("Not Enough");
                EndCooking();
                return;
            }
        }
        StartCooking(); // This checks for ingredients in Inv but does not delete them once Cooking Begins
        foreach (Item ingredient in ingredientsDict.Keys)
        {
            InventoryManager.Instance.Deduct(ingredient, ingredientsDict[ingredient]);
        }
    }
    public void StartCooking()
    {
        Transform spawnLocation = stoveUI.stoveTransform;
        //GameManager.Instance.CloseUI(stoveUI.gameObject);
        UIManager.Instance.ResetUI();
        GameManager.Instance.setCanInteractFalse(spawnLocation.GetComponent<Interactable>());

        
        // Start a timer for the dish by instantiating the loadingBar Prefab.
        GameObject Prefab = Instantiate(loadingBarPrefab, spawnLocation.Find("Stove Canvas").transform);
        Transform prefabTransform = Prefab.transform;
        prefabTransform = spawnLocation;
        LoadingBar loadingScript = Prefab.GetComponent<LoadingBar>();
        loadingScript.dish = dish;
        loadingScript.readyDish = readyDish;
        loadingScript.spawnLocation = spawnLocation;
        loadingScript.gameObject.SetActive(true);
        loadingScript.Initiate();
    }

    public void EndCooking()
    {
        GameManager.Instance.CloseUI(stoveUI.gameObject);
        print("Coooking Cancelled");
    }

    private void CreateIngredientsDict(List<Item> ingredientsList)
    {
        Dictionary<Item, int> tempDict = new Dictionary<Item, int>();

        foreach (var item in ingredientsList)
        {
            if (!tempDict.Keys.Contains(item))
            {
                tempDict[item] = 1;
            }
            else
            {
                tempDict[item] += 1;
            }
        }

        ingredientsDict = tempDict;
    }
}
