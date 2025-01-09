using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private string category = "PlaceHolder Category";//Category for the item
    [SerializeField] private string itemName = "PlaceHolder Name";//Name of the collectible
    [SerializeField] private InventoryManager inventoryManager;//Reference to the InventoryManager

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (inventoryManager == null)
            {
                Debug.LogError("InventoryManager not assigned in the inspector!");
                return;
            }

            //Add collectible to the inventory
            inventoryManager.AddCollectible(category, itemName, 1);

            //Destroy the collectible
            Destroy(gameObject);
        }
    }
}
