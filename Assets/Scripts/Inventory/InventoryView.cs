using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryView : MonoBehaviour
{
    [SerializeField] private Image[] _slots = new Image[5];

    public void AddItem(int slotIndex, Sprite sprite)
    {
        if (slotIndex == -1)
        {
            Debug.LogError("Wrong Index/Not Found Item in Inventory");
            return;
        }

        if (_slots[slotIndex].sprite != sprite)
            _slots[slotIndex].sprite = sprite;
    }

    public void RemoveItem(int slotIndex)
    {
        if (slotIndex == -1)
        {
            Debug.LogError("Wrong Index/Not Found Item in Inventory");
            return;
        }

        if (_slots[slotIndex].sprite != null)
        {
            _slots[slotIndex].sprite = null;
        }
    }
}