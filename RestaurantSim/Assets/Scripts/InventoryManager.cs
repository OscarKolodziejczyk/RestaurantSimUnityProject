using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public Dictionary<Item, int> items = new Dictionary<Item, int>();

    public Transform ItemContent;
    public GameObject InventoryItem;

    public Toggle EnableRemove;

    public InventoryItemController[] InventoryItems;

    public void Awake()
    {
        Instance = this;
    }

    public void Add(Item item)
    {
        if (items.ContainsKey(item))
        {
            items[item] += 1;
        }
        else
        {
            items[item] = 1;
        }
    }

    public void Deduct(Item item, int amount)
    {
        // if itemAmount == amount ... else
        if (items[item] == amount)
        {
            Remove(item);
        }
        else
        {
            items[item] -= amount;
        }
    }

    public void Remove(Item item)
    {
        items.Remove(item);
    }

    public void ListItems()
    {
        foreach (Transform item in ItemContent) 
        {
            Destroy(item.gameObject);
        }

        foreach (var item in items.Keys)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<TMP_Text>();
            var itemIcon = obj.transform.Find("Image").GetComponent<Image>();
            var itemQuantity = obj.transform.Find("Quantity").GetComponent<TMP_Text>();
            var removeButton = obj.transform.Find("DeleteItem").gameObject;

            itemName.text = item.itemName;
            itemIcon.sprite= item.icon;
            if (items[item] > 1)
            {
                itemQuantity.text = items[item].ToString();
            }

            if (EnableRemove.isOn)
            {
                removeButton.gameObject.SetActive(true);
            }
        }

        SetInventoryItems();
    }

    public void EnableItemsRemove()
    {
        if (EnableRemove.isOn)
        {
            foreach (Transform item in ItemContent) 
            {
                item.Find("DeleteItem").gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (Transform item in ItemContent)
            {
                item.Find("DeleteItem").gameObject.SetActive(false);
            }
        }
    }

    public void SetInventoryItems()
    {
        InventoryItems = ItemContent.GetComponentsInChildren<InventoryItemController>();

        foreach (var item in items.Keys)
        {
            int i = 0;
            InventoryItems[i].AddItem(item);
            i++;
        }
    }
}
