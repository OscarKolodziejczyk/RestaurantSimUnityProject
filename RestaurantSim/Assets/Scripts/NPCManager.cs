using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public static NPCManager Instance;
    public List<GameObject> waiterNPCList;
    public List<GameObject> customerNPCList;
    public GameObject customerPrefab;
    public Transform spawnPoint;
    public Transform hostDesk;
    public Transform exitSpace;

    public GameObject counterWithDish;

    private void Awake()
    {
        Instance = this;
    }
    public bool AttemptAlertWaiter(Transform chairTransform)
    {
        if (CheckForCounterWithDish())
        {
            return AlertWaiter(chairTransform, counterWithDish);
        }
        else
        {

            return false;
        }
    }
    public bool AlertWaiter(Transform chairTransform, GameObject counter)
    {
        foreach (GameObject waiterNPC in waiterNPCList)
        {
            if (waiterNPC.GetComponent<WaiterAI>().unactive) // Check *HERE* if a counter actually has a dish
            {
                waiterNPC.GetComponent<GetDish>().GetDishExecute(counter);
                waiterNPC.GetComponent<ServeDish>().targetTable = chairTransform.parent;
                return true;
            }
        }
        return false;
    }

    private bool CheckForCounterWithDish()
    {
        counterWithDish = CounterManager.Instance.GetRandomCounter();
        return counterWithDish != null;
    }

    public void SpawnCustomer()
    {
        GameObject customer = Instantiate(customerPrefab, spawnPoint, false);
        customer.GetComponent<CheckinHost>().hostDeskTransform = hostDesk;
        customer.GetComponent<ExitNPC>().exitSpace = exitSpace;
        customerNPCList.Add(customer);
        customer.GetComponent<CheckinHost>().CheckinHostExecute();
    }
}
