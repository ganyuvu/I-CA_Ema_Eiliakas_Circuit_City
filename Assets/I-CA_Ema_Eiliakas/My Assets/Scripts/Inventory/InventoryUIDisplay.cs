using UnityEngine;
using TMPro;

public class InventoryUIDisplay : MonoBehaviour
{
    [SerializeField] private InventoryManager inventoryManager;//Reference to InventoryManager
    [SerializeField] private Transform inventoryContent;//The content area where items will be displayed
    [SerializeField] private TextMeshProUGUI itemTextPrefab;//Text Prefab for displaying each item as text

    //Update the UI to display current items in inventory
    public void UpdateInventoryUI()
    {
        //Clear any existing items in the UI
        foreach (Transform child in inventoryContent)
        {
            Destroy(child.gameObject);
        }

        //Access the InventoryCollection directly from InventoryManager
        var inventories = inventoryManager.GetInventoryCollection().GetAllInventories();

        //Loop through all categories in the inventory collection
        foreach (var category in inventories)
        {
            //Loop through each item in the inventory category
            foreach (var item in category.Value.GetAllItems())
            {
                //Create a new text item for the inventory UI
                TextMeshProUGUI itemText = Instantiate(itemTextPrefab, inventoryContent);
                
                //Set the text to display the item name and count
                //item.Key is the item name, item.Value is the item count
                itemText.text = item.Key + " x" + item.Value.ToString();
            }
        }
    }
}
