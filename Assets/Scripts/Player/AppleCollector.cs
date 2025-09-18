using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleCollector : MonoBehaviour
{
    [SerializeField] private float _pickUpArea = 2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Apple apple))
        {
            TryPickUpItem(apple);
        }
    }

    private void TryPickUpItem(Apple apple)
    {
        EventHandler.InvokeOnItemPickedUp(apple);
    }
}
