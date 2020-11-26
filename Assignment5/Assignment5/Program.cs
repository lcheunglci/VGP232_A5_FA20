using System;

namespace Assignment5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Adventure of Assignment 5!");

            // TODO: Create an inventory
            Inventory myInventory = new Inventory(10);
            Console.WriteLine("Inventory created.");

            // TODO: Add 2 items to the inventory
            Item potion = new Item("Healing_Potion", 3, ItemGroup.Consumable);
            Item weapon = new Item("Sword", 1, ItemGroup.Equipment);
            myInventory.AddItem(potion);
            myInventory.AddItem(weapon);
            Console.WriteLine("Items added.");

            // Verify the number of items in the inventory.
            Console.WriteLine("\nList of items.");
            myInventory.ListAllItems();
        }
    }
}
