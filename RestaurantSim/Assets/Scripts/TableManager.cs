using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableManager : MonoBehaviour
{
    public List<GameObject> tablesList = new List<GameObject>();
    public static TableManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    public Transform FindFreeSeat()
    {
        foreach (GameObject table in tablesList)
        {
            if (!table.GetComponent<Table>().occupied)
            {
                return table.GetComponent<Table>().seat.transform;
            }
        }
        return null;
    }
}
