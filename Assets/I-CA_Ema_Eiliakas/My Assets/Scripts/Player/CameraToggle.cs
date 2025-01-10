using UnityEngine;

public class CameraToggle : MonoBehaviour
{
    [SerializeField] private Camera primaryCamera;//Main camera
    [SerializeField] private Camera secondaryCamera;//Secondary camera
    [SerializeField] private RayCastDetection rayCastDetection;//Reference to the RayCastDetection script

    private bool isSecondaryActive = false;
    private PlayerControls input;

    void Awake()
    {
        input = new PlayerControls();
        input.Main.Interact.performed += ctx => TryToggleCamera();
    }

    void OnEnable()
    {
        input.Enable();
    }

    void OnDisable()
    {
        input.Disable();
    }

    void Start()
    {
        //Ensure only the primary camera is active at the start
        primaryCamera.enabled = true;
        secondaryCamera.enabled = false;
    }

    private void TryToggleCamera()
    {
        //Check if the player is facing an object and it is in the "Inspecting" layer
        if (rayCastDetection.isFacingObject && rayCastDetection.currentObject.layer == LayerMask.NameToLayer("Inspecting"))
        {
            Debug.Log($"Interacted with: {rayCastDetection.currentObject.name}");
            ToggleCamera();
        }
        else
        {
            Debug.Log("No interactable object in range or not in the 'Inspecting' layer.");
        }
    }

    private void ToggleCamera()
    {
        isSecondaryActive = !isSecondaryActive;
        primaryCamera.enabled = !isSecondaryActive;
        secondaryCamera.enabled = isSecondaryActive;

        Debug.Log(isSecondaryActive ? "Secondary Camera Active" : "Primary Camera Active");
    }

    //This method allows the StateManager to check if the secondary camera is toggld
    public bool IsCameraToggled()
    {
        return isSecondaryActive;
    }
}
