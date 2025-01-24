using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatDish : MonoBehaviour
{
    public WaitForDish waitForDishScript;
    public ExitNPC exitNPCScript;
    public GameObject table;
    public Dish dish;
    public CoinUIPrompt coinUIPrompt;
    public void EatDishExecute(Dish dishServed)
    {
        waitForDishScript.EndWait();
        dish = dishServed;
        print("Eating...");
        Invoke("FinishEating", 1f);
    }

    public void FinishEating()
    {
        table.GetComponentInChildren<DishTable>().FinishDish();
        int totalCost = waitForDishScript.finalTip + dish.price;
        GameManager.Instance.coin += totalCost;
        coinUIPrompt.CoinUIExec(dish);
        exitNPCScript.ExitExecute();
    }
}
