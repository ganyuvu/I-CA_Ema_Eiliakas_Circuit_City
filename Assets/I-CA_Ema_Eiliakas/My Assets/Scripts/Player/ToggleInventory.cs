using UnityEngine;
using UnityEngine.InputSystem;

public class ToggleInventory : MonoBehaviour
{
    [SerializeField] private GameObject inventoryPanel;
    private bool isInventoryOpen = false;

    private PlayerControls input;

    private void Awake()
    {
        input = new PlayerControls();
        AssignInputs();
    }

    private void AssignInputs()
    {
        input.Main.OpenInventory.performed += ctx => ToggleInventoryPanel();
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }

    private void ToggleInventoryPanel()
    {
        //Toggle the inventory open/closed
        isInventoryOpen = !isInventoryOpen;
        inventoryPanel.SetActive(isInventoryOpen);
    }

    //This method allows the StateManager to check if the inventory is open
    public bool IsInventoryOpen()
    {
        return isInventoryOpen;
    }
}
