using System;

public static class EventHandler
{
    public static event Action<Item> OnItemPickedUp;
    public static event Action<Apple> OnAppleSpoiled;

    public static void InvokeOnItemPickedUp(Item item) => OnItemPickedUp?.Invoke(item);
    public static void InvokeOnAppleSpoiled(Apple apple) => OnAppleSpoiled?.Invoke(apple);
}
