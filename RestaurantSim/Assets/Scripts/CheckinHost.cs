using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckinHost : MonoBehaviour
{
    public CustomerAI customerAIScript;
    public Transform hostDeskTransform;
    public void CheckinHostExecute()
    {
        customerAIScript.target = hostDeskTransform;
        customerAIScript.enabled = true;
    }

    private void Update()
    {
        if (customerAIScript.reachedTarget)
        {
            customerAIScript.reachedTarget = false;
            Transform chair = hostDeskTransform.gameObject.GetComponent<HostDesk>().FindFreeChair();
            if (chair != null)
            {
                
                gameObject.GetComponent<GoToChair>().chairTransform = chair;
                
                gameObject.GetComponent<GoToChair>().GoToChairExecute();
            }
            else
            {
                print("=========ExitExec");
                gameObject.GetComponent<ExitNPC>().ExitExecute();
            }
            
            this.enabled = false;
        }
    }
}
