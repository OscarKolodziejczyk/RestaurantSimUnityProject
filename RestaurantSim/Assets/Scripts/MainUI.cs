using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    public TextMeshProUGUI CoinCounterText;

    public void UpdateCoins()
    {
        CoinCounterText.text = GameManager.Instance.coin.ToString();
    }
}
