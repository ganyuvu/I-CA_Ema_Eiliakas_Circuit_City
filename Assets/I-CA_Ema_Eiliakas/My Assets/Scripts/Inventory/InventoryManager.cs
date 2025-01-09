using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private InventoryCollection inventoryCollection;
    [SerializeField] private InventoryUIDisplay inventoryUIDisplay;

    private void Start()
    {
        if (inventoryCollection == null)
        {
            Debug.LogError("InventoryCollection is not assigned!");
        }
    }

    //Method to expose the InventoryCollection
    public InventoryCollection GetInventoryCollection()
    {
        return inventoryCollection;
    }

    //Method to add a collectible to the inventory for a specific category
    public void AddCollectible(string category, string itemName, int quantity = 1)
    {
        //Get the inventory for the specified category
        var inventory = inventoryCollection.GetInventory(category);
        //Add the item to the inventory.
        inventory.AddItem(itemName, quantity);
        //Debug
        Debug.Log($"Added x{quantity} {itemName} to {category} category.");

        //Update in the UI
        inventoryUIDisplay.UpdateInventoryUI();
    }

    public int GetCollectibleCount(string category, string itemName)
    {
        //Get the inventory for the specified category
        var inventory = inventoryCollection.GetInventory(category);
        //Return the number of the specified item in the inventory
        return inventory.GetItemCount(itemName);
    }
}
