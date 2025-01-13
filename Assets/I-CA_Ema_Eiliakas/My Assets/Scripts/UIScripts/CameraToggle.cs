using UnityEngine;

public class CameraToggle : MonoBehaviour
{
    [SerializeField] private GameObject primaryCameraObject;//Main camera GameObject
    private GameObject secondaryCameraObject;//Secondary camera GameObject
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
        //Ensure only the primary camera GameObject is active at the start
        primaryCameraObject.SetActive(true);
        //Start with no secondary camera GameObject
        secondaryCameraObject = null;
    }

    private void TryToggleCamera()
    {
        //Check if the player is facing an object and it has a CameraSwitcher component
        if (rayCastDetection.isFacingObject)
        {
            CameraSwitcher cameraSwitcher = rayCastDetection.currentObject.GetComponent<CameraSwitcher>();
            if (cameraSwitcher != null)
            {
                secondaryCameraObject = cameraSwitcher.GetObjectCamera().gameObject;//Get camera GameObject when set
                if (secondaryCameraObject != null)
                {
                    Debug.Log($"Switched to camera: {secondaryCameraObject.name}");
                    ToggleCamera();
                }
                else
                {
                    Debug.Log("No camera GameObject set for this object.");
                }
            }
            else
            {
                Debug.Log("No CameraSwitcher component found on the object.");
            }
        }
        else
        {
            Debug.Log("No interactable object in range.");
        }
    }

    private void ToggleCamera()
    {
        if (secondaryCameraObject != null)
        {
            //Toggle between primary and secondary camera GameObjects
            isSecondaryActive = !isSecondaryActive;
            primaryCameraObject.SetActive(!isSecondaryActive);//Deactivate the primary camera GameObject
            secondaryCameraObject.SetActive(isSecondaryActive);//Activate the secondary camera GameObject

            Debug.Log(isSecondaryActive ? "Secondary Camera Active" : "Primary Camera Active");
        }
    }

    //This method allows the StateManager to check if the secondary camera is toggled
    public bool IsCameraToggled()
    {
        return isSecondaryActive;
    }
}
