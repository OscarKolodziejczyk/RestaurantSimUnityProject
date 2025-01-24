using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : MonoBehaviour
{
    public WaiterAI waiterAIScript;
    public GameObject waiterGFX;
    public Sprite normalWaiterSprite;
    public void IdleExecute()
    {
        print("Waiter Idle Exec");
        waiterGFX.GetComponent<SpriteRenderer>().sprite = normalWaiterSprite;
    }
}
