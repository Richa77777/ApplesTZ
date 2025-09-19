using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private InventoryView _inventoryView;
    private Inventory _currentInventory;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        _currentInventory = new Inventory();
    }

    private void OnEnable()
    {
        EventHandler.OnItemPickedUp += AddItem;
        EventHandler.OnAppleSpoiled += RemoveItem;
    }

    private void OnDisable()
    {
        EventHandler.OnItemPickedUp -= AddItem;
        EventHandler.OnAppleSpoiled -= RemoveItem;
    }

    public void AddItem(Item item)
    {
        if (_currentInventory.AddItem(item))
        {
            item.OnAddedInInventory.Invoke();
            _inventoryView.AddItem(_currentInventory.GetIndexOfItem(item), item.Icon);
        }
    }

    public void RemoveItem(Item item)
    {
        if (!item.InInventory) return;

        int index = _currentInventory.GetIndexOfItem(item);
        if (index == -1)
        {
            Debug.LogWarning("Trying to remove item that is not in inventory: " + item.name);
            return;
        }

        _inventoryView.RemoveItem(index);
        _currentInventory.RemoveItem(item);
    }

}
