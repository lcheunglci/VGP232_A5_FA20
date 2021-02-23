using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment5
{
    public class Inventory
    {
        // The dictionary items consist of the item and the quantity
        private Dictionary<Item, int> items = new Dictionary<Item, int>();

        public int AvailableSlots 
        { 
            get
            {
                return availableSlots;
            } 
        }

        public int MaxSlots
        {
            get
            {
                return MaxSlots;
            }
        }


        // The available slots to add item, once it's 0, you cannot add any more items.
        private int availableSlots;

        // The max available slots which is set only in the constructor.
        private int maxSlots;
        public Inventory(int slots)
        {
            maxSlots = slots;
            availableSlots = maxSlots;
        }

        /// <summary>
        /// Removes all the items, and restore the original number of slots.
        /// </summary>
        public void Reset()
        {
            items.Clear();
            availableSlots = maxSlots;
        }

        /// <summary>
        /// Removes the item from the items dictionary if the count is 1 otherwise decrease the quantity.
        /// </summary>
        /// <param name="name">The item name</param>
        /// <param name="found">The item if found</param>
        /// <returns>True if you find the item, and false if it does not exist.</returns>
        public bool TakeItem(string name, out Item found)
        {
            foreach (var key in items.Keys)
            {
                if (key.Name == name)
                {
                    found = key;
                    if (items[key] == 1)
                    {
                        items.Remove(key);
                        availableSlots++;
                    }
                    else
                    {
                        --items[key];
                    }
                    return true;
                }
            }
            found = null;
            return false;
        }

        /// <summary>
        /// Checks if there is space for a unique item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool AddItem(Item item)
        {
            // Add it in the items dictionary and increment it the number if it already exist
            // Reduce the slot once it's been added.
            // returns false if the inventory is full
            foreach(var key in items.Keys)
            {
                if(item == key)
                {
                    ++items[key];
                    availableSlots--;
                    return true;
                }
            }
            if (availableSlots == 0)
            {
                return false;
            }

            items.Add(item, 1);
            return true;
        }

        /// <summary>
        /// Iterates through the dictionary and create a list of all the items.
        /// </summary>
        /// <returns></returns>
        public List<Item> ListAllItems()
        {
            // use a foreach loop to iterate through the key value pairs and duplicate the item base on the quantity.
            List<Item> allItems = new List<Item>();
            foreach (var item in items.Keys)
            {
                allItems.Add(item);
            }
            return allItems;
        }
    }
}
