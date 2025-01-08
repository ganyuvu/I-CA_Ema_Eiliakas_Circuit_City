using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectPickup : MonoBehaviour
{
    [SerializeField] private RayCastDetection rayCastDetection;//Reference to the RayCastDetection script
    private PlayerControls input;//The input system controls class
    private InputAction pickupAction;//The pickup input action

    private bool isHoldingObject = false;//Tracks if the player is holding an object
    private GameObject heldObject;//Reference to the currently held object

    void Awake()
    {
        //Initialize the input system and get the input action for pickup
        input = new PlayerControls();
        pickupAction = input.Main.PickUpOrDrop;
    }

    void OnEnable()
    {
        //Enable the input action
        pickupAction.Enable();
    }

    void OnDisable()
    {
        //Disable the input action
        pickupAction.Disable();
    }

    void Update()
    {
        //Check if the pickup action is triggered
        if (pickupAction.triggered)
        {
            if (isHoldingObject)
            {
                //If holding an object, drop it
                PerformDrop();
            }
            else if (rayCastDetection.isFacingObject)
            {
                //If not holding an object and facing one, pick it up
                PerformPickup();
            }
        }
    }

    //Method to perform the pickup action
    void PerformPickup()
    {
        if (rayCastDetection.currentObject != null)
        {
            heldObject = rayCastDetection.currentObject;
            isHoldingObject = true;

            //Log the pickup action
            Debug.Log("Picked up object: " + heldObject.name);
        }
    }

    //Method to perform the drop action
    void PerformDrop()
    {
        //Log the drop action
        Debug.Log("Dropped object: " + heldObject.name);

        //Reset the holding status
        heldObject = null;
        isHoldingObject = false;
    }
}
