using UnityEngine;

public class StateManager : MonoBehaviour
{
    //Possible states for the player
    private enum PlayerState
    {
        Normal,
        Inventory
    }

    //Current state of the player
    private PlayerState currentState;

    [SerializeField] private ToggleInventory toggleInventory;//Reference to the ToggleInventory script
    [SerializeField] private PlayerController playerController;//Reference to the PlayerController script

    void Start()
    {
        //Set the initial state to Normal
        currentState = PlayerState.Normal;
    }

    void Update()
    {
        //Transition based on input
        HandleStateTransitions();
    }

    private void HandleStateTransitions()
    {
        //Check for the action
        //Check if inventory is already toggled
        if (toggleInventory.IsInventoryOpen())
        {
            if (currentState != PlayerState.Inventory)
            {
                SwitchToInventoryState();
            }
        }
        else
        {
            if (currentState != PlayerState.Normal)
            {
                SwitchToNormalState();
            }
        }
    }

    //Switch to the inventory state
    private void SwitchToInventoryState()
    {
        currentState = PlayerState.Inventory;
        //Disable player movement
        Debug.Log("Switched to Inventory State");
        playerController.enabled = false;
    }

    //Switch to the normal state
    private void SwitchToNormalState()
    {
        currentState = PlayerState.Normal;

        //Update the game to allow player movement
        Debug.Log("Switched to Normal State");
        playerController.enabled = true;
    }
}
