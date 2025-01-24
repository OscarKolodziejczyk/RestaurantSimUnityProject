using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeManager : MonoBehaviour
{
    public static Action OnHourChange;
    public static Action OnMinuteChange;
    
    public static int Hour { get; private set; }
    public static int Minute { get; private set; }

    private float minuteToRealTime = 0.5f;
    private float timer;

    private void Start()
    {
        Minute = 0;
        Hour = 6;
        timer = minuteToRealTime;
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Minute++;
            OnMinuteChange?.Invoke();
            if (Minute >= 60)
            {
                Minute = 0;
                Hour++;
                OnHourChange?.Invoke();
            }
            timer = minuteToRealTime;
        }
    }
}
