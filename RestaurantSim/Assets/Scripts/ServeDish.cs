using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServeDish : MonoBehaviour
{
    public WaiterAI waiterAIScript;
    public Transform targetTable;
    public Dish dish;
    public void ServeDishExecute()
    {
        this.enabled = true;
        waiterAIScript.target = targetTable;
    }

    private void Update()
    {
        if (waiterAIScript.reachedTarget)
        {
            waiterAIScript.reachedTarget = false;

            targetTable.gameObject.GetComponentInChildren<DishTable>().SetDish(dish);

            targetTable.gameObject.GetComponent<Table>().customer.GetComponent<EatDish>().table = targetTable.gameObject;
            targetTable.gameObject.GetComponent<Table>().customer.GetComponent<EatDish>().EatDishExecute(dish);

            waiterAIScript.unactive = true;

            gameObject.GetComponent<Idle>().IdleExecute();
            this.enabled = false;
        }
    }
}
