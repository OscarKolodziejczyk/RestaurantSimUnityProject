using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitNPC : MonoBehaviour
{
    public CustomerAI customerAIScript;
    public Transform exitSpace;
    public void ExitExecute()
    {
        this.enabled = true;
        customerAIScript.target = exitSpace;
        customerAIScript.reachedTarget = false;
        customerAIScript.enabled = true;
        
        print("Exit Cusotomer NPC");
    }

    public void Update()
    {
        if (customerAIScript.reachedTarget)
        {
            NPCManager.Instance.customerNPCList.Remove(gameObject);
            Destroy(gameObject);
            //TODO: Reset the prefab so it's ready to spawn again
        }
    }
}
