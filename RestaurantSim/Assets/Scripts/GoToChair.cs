using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToChair : MonoBehaviour
{
    public CustomerAI customerAIScript;
    public Transform chairTransform;
    public WaitForDish waitForDishScript;

    public void GoToChairExecute()
    {
        this.enabled = true;
        customerAIScript.target = chairTransform;
    }

    private void Update()
    {
        if (customerAIScript.reachedTarget)
        {
            customerAIScript.reachedTarget = false;
            customerAIScript.enabled = false;

            chairTransform.gameObject.GetComponentInParent<Table>().occupied = true;
            chairTransform.gameObject.GetComponentInParent<Table>().customer = gameObject;

            waitForDishScript.WaitExecute(chairTransform);

            //customerAIScript.target = null;
            //gameObject.transform.position = chairTransform.position;
            this.enabled = false;
        }
    }
}
