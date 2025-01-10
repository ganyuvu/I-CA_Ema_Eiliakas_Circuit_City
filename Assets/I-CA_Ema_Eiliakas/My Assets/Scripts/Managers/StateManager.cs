using UnityEngine;

public class StateManager : MonoBehaviour
{
    //Possible states for the player
    private enum PlayerState
    {
        Normal,
        Inventory,
        Inspecting
    }

    //Current state of the player
    private PlayerState currentState;

    [SerializeField] private ToggleInventory toggleInventory;//Reference to the ToggleInventory script
    [SerializeField] private PlayerController playerController;//Reference to the PlayerController script
    [SerializeField] private CameraToggle cameraToggle;//Reference to the CameraToggle script

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
        else if (cameraToggle.IsCameraToggled())
        {
            if (currentState != PlayerState.Inspecting)
            {
                //Transition to Inspecting State
                SwitchToInspectingState(true);
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

    //Switch to the inspecting State
    public void SwitchToInspectingState(bool isInspecting)
    {
        if (isInspecting)
        {
            currentState = PlayerState.Inspecting;
            Debug.Log("Switched to Inspecting State");
            //Disable player movement
            playerController.enabled = false;
        }
        else
        {
            SwitchToNormalState(); // Switch back to normal state
        }
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
