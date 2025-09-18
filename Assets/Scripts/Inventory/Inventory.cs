using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    [SerializeField] private List<Item> _items = new List<Item>();
    private int _inventorySize = 5;

    public Inventory()
    {
        // Initialize the list with empty slots of fixed size
        for (int i = 0; i < _inventorySize; i++)
            _items.Add(null);
    }

    // Add an item to the first available (empty) slot
    public bool AddItem(Item item)
    {
        for (int i = 0; i < _inventorySize; i++)
        {
            if (_items[i] == null)
            {
                _items[i] = item;
                return true;
            }
        }
        return false; // no free slot available
    }

    public bool RemoveItem(Item item)
    {
        int index = _items.IndexOf(item);

        if (index != -1)
        {
            _items[index] = null; // clear the slot
            return true;
        }
        return false;
    }

    public int GetIndexOfItem(Item item)
    {
        return _items.IndexOf(item);
    }
}