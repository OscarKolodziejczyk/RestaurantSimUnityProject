using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Dish", menuName = "Dish/Create New Dish")]
public class Dish : ScriptableObject
{
    public string dishName;
    public string description;
    public int amountCooked;

    public int price;
    private int _basePrice;

    public float time;
    private float _baseTime;

    public int servingCount;
    private int _baseServingCount;

    public List<string> cuisine;
    public List<Item> ingredientsList = new List<Item>();
    public Sprite cookingSprite;
    public Sprite finishedSprite;
}
