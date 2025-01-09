using System.Collections.Generic;

[System.Serializable]
public class Inventory
{
    //Dictionary to store items name and qunatity
    private Dictionary<string, int> items = new Dictionary<string, int>();

    //Method to add Item to inventory
    public void AddItem(string itemName, int quantity = 1)
    {
        //If the item already exists in the inventory, increase its quantity
        if (items.ContainsKey(itemName))
        {
            items[itemName] += quantity;
        }
        //Else, add the item to the inventory with the given quantity.
        else
        {
            items[itemName] = quantity;
        }
    }

    public int GetItemCount(string itemName)
    {
        //Check if the item exists in the inventory
        //If it does, return its quantity
        //If not, return 0
        return items.ContainsKey(itemName) ? items[itemName] : 0;
    }

    //Method to retrieve all items in the inventory.
    public Dictionary<string, int> GetAllItems()
    {
        //Create and return a copy of the items dictionary
        //This is to avoid direct modification.
        return new Dictionary<string, int>(items);
    }
}
