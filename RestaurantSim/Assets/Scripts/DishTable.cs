using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishTable : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Table table;

    public void SetDish(Dish dish)
    {
        spriteRenderer.sprite = dish.finishedSprite;
        spriteRenderer.enabled = true;
    }

    public void FinishDish()
    {
        table.occupied = false;
        spriteRenderer.enabled = false;
        spriteRenderer.sprite = null;
    }
}
