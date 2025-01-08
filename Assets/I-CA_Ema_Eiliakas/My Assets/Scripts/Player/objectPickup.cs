using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectPickup : MonoBehaviour
{
    [SerializeField] private RayCastDetection rayCastDetection;//Reference to the RayCastDetection script
    [SerializeField] private Transform holdPosition;
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

        //If holding an object, ensure it follows the hold position
        if (isHoldingObject && heldObject != null)
        {
            heldObject.transform.position = holdPosition.position;
            heldObject.transform.rotation = holdPosition.rotation;
        }
    }

    //Method to perform the pickup action
    void PerformPickup()
    {
        if (rayCastDetection.currentObject != null)
        {
            heldObject = rayCastDetection.currentObject;
            isHoldingObject = true;

            //Attach the object to the player at the hold position
            heldObject.transform.SetParent(holdPosition);
            heldObject.transform.localPosition = Vector3.zero;
            heldObject.transform.localRotation = Quaternion.identity;

            Rigidbody objectRigidbody = heldObject.GetComponent<Rigidbody>();
            if (objectRigidbody != null)
            {
                objectRigidbody.isKinematic = true;
            }

            //Log the pickup action
            Debug.Log("Picked up object: " + heldObject.name);
        }
    }

    //Method to perform the drop action
    void PerformDrop()
    {
        //Detach the object from the player
        heldObject.transform.SetParent(null);

        //Re-enable the object's movement by enabling its Rigidbody component
        Rigidbody objectRigidbody = heldObject.GetComponent<Rigidbody>();
        if (objectRigidbody != null)
        {
            objectRigidbody.isKinematic = false;
        }

        //Log the drop action
        Debug.Log("Dropped object: " + heldObject.name);

        //Reset the holding status
        heldObject = null;
        isHoldingObject = false;
    }
}
