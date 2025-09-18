using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Action OnAddedInInventory;
    [field: SerializeField] public Sprite Icon { get; private set; }

    protected void SetIcon(Sprite sprite)
    {
        if (Icon != sprite)
            Icon = sprite;
    }
}