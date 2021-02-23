using System;

namespace Assignment5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Adventure of Assignment 5!");

            // TODO: Create an inventory
            // TODO: Add 2 items to the inventory
            // Verify the number of items in the inventory.
            Inventory inventory = new Inventory(10);
            inventory.AddItem(new Item("Potion", 4, ItemGroup.Consumable));
            inventory.AddItem(new Item("Key", 3, ItemGroup.Key));
            var lists = inventory.ListAllItems();
            lists.ForEach(Console.WriteLine);
        }
    }
}
