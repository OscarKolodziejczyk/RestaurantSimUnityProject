using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sale : MonoBehaviour
{
    public int price;
    public Item item;
    // Checks Price against Amount of gold player has
    // If #gold >= Price, give player the item in inventory & Deduct the gold.
    public void BeginSale()
    {
        if (GameManager.Instance.coin >= price)
        {
            GiveItem(item);
            GameManager.Instance.coin -= price;
            GameManager.Instance.UpdateCoins();
        }
        else
        {
            print("Not Enough Coin");
        }
    } 
    private void GiveItem(Item item)
    {
        InventoryManager.Instance.Add(item);
    }

}
