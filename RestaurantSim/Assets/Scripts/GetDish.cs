using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GetDish : MonoBehaviour
{
    public WaiterAI waiterAIScript;
    public GameObject waiterGFX;
    public Sprite carryingDishSprite;

    public GameObject targetCounter;


    public void GetDishExecute(GameObject counter)
    {
        this.enabled = true;

        targetCounter = counter;

        SetAIScript();
    }

    private void SetAIScript()
    {
        waiterAIScript.target = targetCounter.transform;
        waiterAIScript.unactive = false;
        waiterAIScript.enabled = true;
    }

    void Update()
    {
        if (waiterAIScript.reachedTarget) 
        {
            waiterAIScript.reachedTarget = false;

            targetCounter.GetComponent<Counter>().DeductServing();
            waiterGFX.GetComponent<SpriteRenderer>().sprite = carryingDishSprite;

            gameObject.GetComponent<ServeDish>().dish = targetCounter.GetComponent<Counter>().Serving.GetComponent<Serving>().dish;
            gameObject.GetComponent<ServeDish>().ServeDishExecute();

            this.enabled = false;
            
        }
    }
}
