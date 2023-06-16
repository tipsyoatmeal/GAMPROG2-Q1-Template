using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    private ItemData itemData;
    public Image itemIcon;

    public void SetItem(ItemData data)
    {
        // TODO
        // Set the item data the and icons here
        itemIcon.enabled = true;
        itemIcon.sprite = data.icon;
        itemData = data;
    }

    public void UseItem()
    {
        if(itemData.type == ItemType.Equipabble)
        {
            InventoryManager.Instance.UseItem(itemData);
            itemData = null;
            itemIcon.sprite = null;
            itemIcon.enabled = false;
        }
        if(itemData.type == ItemType.Consumable)
        {
            InventoryManager.Instance.UseItem(itemData);
            itemData = null;
            itemIcon.sprite = null;
            itemIcon.enabled = false;
        }

        

        // TODO
        // Reset the item data and the icons here
    }

    public bool HasItem()
    {
        return itemData != null;
    }

    public bool hasKey()
    {
        return itemData.type == ItemType.StoryItem;
    }

    public void DeleteKey()
    {
        itemIcon.gameObject.SetActive(false);
        itemData=null;
        itemIcon.sprite = null;
    }
}
