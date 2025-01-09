using System.Collections.Generic;
using UnityEngine;

//This script defines a ScriptableObject that acts as a collection of multiple inventories
//This allows us to organize items into different categories
[CreateAssetMenu(fileName = "InventoryCollection", menuName = "Inventory/Collection")]
public class InventoryCollection : ScriptableObject
{
    //A dictionary to store multiple inventories categorized by a string
    private Dictionary<string, Inventory> inventories = new Dictionary<string, Inventory>();

    //Method to get an inventory for a specific category
    public Inventory GetInventory(string category)
    {
        //If the inventory for the given category does not exist, create a new one
        if (!inventories.ContainsKey(category))
        {
            inventories[category] = new Inventory();
        }

        //Return the inventory for the given category
        return inventories[category];
    }

    //Method to get all inventories
    public Dictionary<string, Inventory> GetAllInventories()
    {
        //Create and return a copy of the items dictionary
        //This is to avoid direct modification.
        return new Dictionary<string, Inventory>(inventories);
    }
}
