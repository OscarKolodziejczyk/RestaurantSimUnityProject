using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public float timeToSpawn;
    private bool spawned = false;
    private void OnEnable()
    {
        TimeManager.OnMinuteChange += TimeCheck;
    }

    private void OnDisable()
    {
        TimeManager.OnMinuteChange -= TimeCheck;
    }

    private void TimeCheck()
    {

    }

    void Update()
    {
        if (TimeManager.Minute % timeToSpawn == 0 && !spawned)
        {
            NPCManager.Instance.SpawnCustomer();
            spawned = true;
        }
        else if (TimeManager.Minute % timeToSpawn != 0)
        {
            spawned = false;
        }
    }
}
