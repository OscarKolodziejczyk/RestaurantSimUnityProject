using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DishAchievement : MonoBehaviour
{
    public Dish dish;
    public TextMeshProUGUI dishName;
    public TextMeshProUGUI amountCooked;
    public Image dishImage;
    public Image backgroundImage;


    private void Awake()
    {
        dishImage.sprite = dish.finishedSprite;
        dishName.text = dish.name;
        UpdateAchievements();
    }

    public void UpdateAchievements()
    {
        amountCooked.text = $"Cooked: {dish.amountCooked}";
    }
}
