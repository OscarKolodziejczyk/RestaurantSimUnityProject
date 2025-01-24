using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    
    public bool hasDish = false;
    public GameObject Serving = null;
    public Dish currDish = null;
    
    public void SetDish(Dish dish, GameObject servingPrefab)
    {
        if (currDish == null)
        {
            print("set New dish");
            GameObject currServing = Instantiate(servingPrefab, gameObject.transform, true);

            currServing.GetComponent<Serving>().dish = dish;
            currServing.GetComponent<Serving>().counter = gameObject;
            currServing.GetComponent<Serving>().InitiateServing();

            Serving = currServing;
            currDish = dish;
            hasDish = true;
        }
        else
        {
            Serving.GetComponent<Serving>().servings += currDish.servingCount;
            Serving.GetComponent<Serving>().UpdateServingInfo();
        }
    }

    public void DeductServing()
    {
        if (hasDish) 
        { 
        Serving.GetComponent<Serving>().TakeAwayServing();
        }
    }
}
