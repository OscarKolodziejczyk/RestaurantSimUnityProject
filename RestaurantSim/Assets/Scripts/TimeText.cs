using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class TimeText : MonoBehaviour
{
    public TextMeshProUGUI timeTextBox;

    private void OnEnable()
    {
        TimeManager.OnMinuteChange += UpdateTime;
        TimeManager.OnHourChange += UpdateTime;
    }

    private void OnDisable()
    {
        TimeManager.OnMinuteChange -= UpdateTime;
        TimeManager.OnHourChange -= UpdateTime;
    }

    private void UpdateTime()
    {
        timeTextBox.text = $"{TimeManager.Hour:00}:{TimeManager.Minute:00}";
    }
}
