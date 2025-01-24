using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForDish : MonoBehaviour
{
    // Class used to determine tip, will calculate how long the wait -> lower wait time = higher tip
    public int finalTip = 1;
    public EatDish eatDishScript;
    private bool waiterIsComing = false;
    private Transform chair;

    public void WaitExecute(Transform chairTransform)
    {
        chair = chairTransform;
        if (NPCManager.Instance.AttemptAlertWaiter(chairTransform))
        {
            waiterIsComing = true;
        }
        else
        {
            AlertWaiterAgain();
        }
    }

    public void AlertWaiterAgain()
    {
        waiterIsComing = NPCManager.Instance.AttemptAlertWaiter(chair);
        if (!waiterIsComing)
        {
            Invoke("AlertWaiterAgain", 1f);
        }
        else
        {
            this.CancelInvoke();
        }
        print("Alerted Again");
    }

    public void EndWait()
    {
        this.CancelInvoke();
        return;
    }
}
