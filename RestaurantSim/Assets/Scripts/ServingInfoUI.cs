using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ServingInfoUI : MonoBehaviour
{
    public TMP_Text textBox;
    public string dishName = "dishName";
    public int servingCount = 0;

    private void Awake()
    {
        UpdateText();
    }

    public void UpdateText()
    {
        textBox.text = $"{dishName}\nServings: {servingCount}";
    }
}
