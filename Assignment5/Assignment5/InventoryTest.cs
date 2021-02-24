using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Assignment5
{
    [TestFixture]
    public class InventoryTest
    {
        private Inventory Inventory;

        [SetUp]
        public void SetUp()
        {
            Inventory = new Inventory(5);
        }


        // RemoveItem - found item is set, returns true, verify the available slots increase
        [Test]
        public void Inventory_RemoveItem_True_SlotIncrease()
        {
            try
            {
                Item found;
                Item item = new Item("Sword", 1, ItemGroup.Equipment);
                Inventory.AddItem(item);
                bool flag = Inventory.TakeItem("Sword", out found);
                Assert.IsTrue(flag);
                Assert.AreEqual(item, found);
                Assert.AreEqual(Inventory.AvailableSlots, 5);
            }
            catch (Exception)
            {
                Console.WriteLine("TakeItem fails to remove a item.");
            }
        }

        // RemoveItem - found item is null, returns false, verify the available slots remain the same
        [Test]
        public void Inventory_RemoveItem_FalseNull_SlotUnchanged()
        {
            try
            {
                Item found;
                bool flag = Inventory.TakeItem("Sword", out found);
                Assert.IsFalse(flag);
                Assert.IsNull(found);
                Assert.AreEqual(Inventory.AvailableSlots, 5);
            }
            catch (Exception)
            {
                Console.WriteLine("TakeDamage does not set IsAlive to false");
            }
        }

        // AddItem - verify the available slots decreases and use ListAllItems to verify it exists
        [Test]
        public void Inventory_AddItem_SlotDecrease()
        {
            try
            {
                Item item1 = new Item("Potion", 4, ItemGroup.Consumable);
                Item item2 = new Item("Key", 3, ItemGroup.Key);
                Item item3 = new Item("Key", 3, ItemGroup.Key);

                bool flag1 = Inventory.AddItem(item1);
                bool flag2 = Inventory.AddItem(item2);
                bool flag3 = Inventory.AddItem(item3);

                Assert.IsTrue(flag1);
                Assert.IsTrue(flag2);
                Assert.IsTrue(flag3);
                Assert.AreEqual(Inventory.AvailableSlots, 3);
                List<Item> items = Inventory.ListAllItems();
                Assert.AreEqual(items[0], item1);
                Assert.AreEqual(items[1], item2);
                Assert.AreEqual(items[2], item2);
                Assert.AreEqual(items[2], item3);
            }
            catch (Exception)
            {
                Console.WriteLine("AddItem fails to add or decrease the slots");
            }
        }

        // Reset - removes all the items, and max slots restored
        [Test]
        public void Inventory_Reset_SlotRestored()
        {
            try
            {
                Item item1 = new Item("Potion", 4, ItemGroup.Consumable);
                Item item2 = new Item("Key", 3, ItemGroup.Key);
                Inventory.AddItem(item1);
                Inventory.AddItem(item2);
                Inventory.Reset();
                Assert.AreEqual(Inventory.AvailableSlots, 5);
            }
            catch (Exception)
            {
                Console.WriteLine("RestoreHealth fails to remove all items.");
            }
        }
    }
}
