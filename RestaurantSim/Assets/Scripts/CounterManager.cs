using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterManager : MonoBehaviour
{
    public List<GameObject> countersList = new List<GameObject>();
    public static CounterManager Instance;
    public GameObject servingPrefab;
    

    private void Awake()
    {
        Instance = this; 
    }

    public bool AddDishToCounter(Dish dish)
    {
        GameObject emptyCounter = null;

        foreach (GameObject counterObj in countersList)
        {

            if (counterObj.GetComponent<Counter>().currDish == dish)
            {
                counterObj.GetComponent<Counter>().SetDish(dish, servingPrefab);
                return true;
            }
            else if (emptyCounter == null && !counterObj.GetComponent<Counter>().hasDish)
            {
                emptyCounter = counterObj;
            }
        }
        if (emptyCounter != null)
        {
            emptyCounter.GetComponent<Counter>().SetDish(dish, servingPrefab);
            return true;
        }
        return false;
    }

    public GameObject GetRandomCounter()
    {
        List<GameObject> filledCounterList = new List<GameObject>();
        foreach (GameObject counterObj in countersList)
        {
            if (counterObj.GetComponent<Counter>().hasDish)
            {
                filledCounterList.Add(counterObj);
            }
        }
        if (filledCounterList.Count > 0)
        {
            int r = Random.Range(0, filledCounterList.Count);
            print(r);
            return filledCounterList[r];
        }
        else
        {
            print("No Counters with Dishes");
            return null;
        }
    }
}
