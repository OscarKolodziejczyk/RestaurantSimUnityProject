using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostDesk : MonoBehaviour
{
    public Transform FindFreeChair()
    {
        return TableManager.Instance.FindFreeSeat();
    }
}
