using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUIDisplay : MonoBehaviour
{
    [SerializeField] private InventoryManager inventoryManager;//Reference to InventoryManager
    [SerializeField] private Transform inventoryContent;//The content area where items will be displayed
    [SerializeField] private GameObject itemPrefab;//Prefab for displaying inventory items
    [SerializeField] private Sprite defaultIcon;//Default icon if no specific image is available

    //Update the UI to display current items in inventory
    public void UpdateInventoryUI()
    {
        //Clear any existing items in the UI
        foreach (Transform child in inventoryContent)
        {
            Destroy(child.gameObject);
        }

        //Ensure prefab is assigned
        if (itemPrefab == null)
        {
            Debug.LogError("Item prefab is not assigned in the Inspector!");
            return;
        }

        //Get inventories
        var inventories = inventoryManager.GetInventoryCollection().GetAllInventories();

        foreach (var category in inventories)
        {
            foreach (var item in category.Value.GetAllItems())
            {
                //Instantiate the prefab
                GameObject itemDisplay = Instantiate(itemPrefab, inventoryContent);

                //Set the item's name and quantity
                var itemNameTransform = itemDisplay.transform.Find("ItemName");
                if (itemNameTransform != null)
                {
                    TextMeshProUGUI itemText = itemNameTransform.GetComponent<TextMeshProUGUI>();
                    if (itemText != null)
                    {
                        itemText.text = item.Key + " x" + item.Value.ToString();
                    }
                }

                //Set the item's icon
                var iconTransform = itemDisplay.transform.Find("Icon");
                if (iconTransform != null)
                {
                    Image iconImage = iconTransform.GetComponent<Image>();
                    if (iconImage != null)
                    {
                        //Assign a default icon or a specific one if available
                        iconImage.sprite = GetItemIcon(item.Key) ?? defaultIcon;
                    }
                }
            }
        }
    }
    private Sprite GetItemIcon(string itemName)
    {
        //Return null to use the default icon
        return null;
    }
}
