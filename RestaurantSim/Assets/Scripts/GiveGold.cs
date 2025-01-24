using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveGold : MonoBehaviour
{
    public void GiveOneGold()
    {
        GameManager.Instance.coin += 1;
    }
}
