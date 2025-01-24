using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesManager : MonoBehaviour
{
    public static UpgradesManager Instance;
    public float UniversalPriceMult = 1f;
    public float JapaneseCuisineMult = 1f;
    public float AmericanCuisineMult = 1f;
    private void Awake()
    {
        Instance = this;
    }

}
