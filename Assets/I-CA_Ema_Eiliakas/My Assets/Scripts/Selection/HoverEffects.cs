using UnityEngine;

namespace GD.Selection
{
    public class HighlightSelectionResponse : MonoBehaviour, ISelectionResponse
    {
        [SerializeField] private Camera mainCamera;//Reference to the main camera
        [SerializeField] private Color hoverColor = Color.red;//Color to change to when hovering (red by default)
        [SerializeField] private LayerMask interactableLayers;//Layer mask to specify which layers can be hovered

        [SerializeField] private Color andPlateColor = Color.red; // Color for ANDPlate layer
        [SerializeField] private Color orPlateColor = Color.green; // Color for ORPlate layer
        [SerializeField] private Color nandPlateColor = Color.blue; // Color for NANDPlate layer
        [SerializeField] private Color SecurityCameras = Color.red; // Color for NANDPlate layer

        [SerializeField] private MouseRay mouseRay; // Reference to the MouseRay script

        private Transform currentHoveredObject;//Track the currently hovered object
        private Color originalColor;//Store the original color of the object
        private Renderer objectRenderer;//Get the renderer of the object

        private void Start()
        {
            //Ensure we have the main camera assigned, otherwise grab the default main camera
            if (mainCamera == null) 
                mainCamera = Camera.main;

            if (mainCamera == null)
                Debug.LogError("Main Camera is not assigned and no camera found.");
        }

        private void Update()
        {
            Ray ray = mouseRay.CreateRay();
            RaycastHit hit;

            //Check for raycast hit on the specified layers
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, interactableLayers))
            {
                //If we hit an object that belongs to the specified layers, change its color
                HandleObjectHover(hit.transform);
            }
            else
            {
                //If no object is hit, reset the color of the previously hovered object
                if (currentHoveredObject != null)
                {
                    ResetObjectColor();
                    currentHoveredObject = null;
                }
            }
        }

private void HandleObjectHover(Transform obj)
{
    // Only change the color if it's a new hovered object
    if (currentHoveredObject != obj)
    {
        // Reset previous object's color if any
        if (currentHoveredObject != null)
            ResetObjectColor();

        // Store the new hovered object and change its color
        currentHoveredObject = obj;
        objectRenderer = obj.GetComponent<Renderer>();

        if (objectRenderer != null)
        {
            // Check layer and apply respective color using if statements
            if (obj.gameObject.layer == LayerMask.NameToLayer("ANDPlate"))
            {
                objectRenderer.material.color = andPlateColor;
            }
            else if (obj.gameObject.layer == LayerMask.NameToLayer("ORPlate"))
            {
                objectRenderer.material.color = orPlateColor;
            }
            else if (obj.gameObject.layer == LayerMask.NameToLayer("NANDPlate"))
            {
                objectRenderer.material.color = nandPlateColor;
            }
            else if (obj.gameObject.layer == LayerMask.NameToLayer("Inspecting"))
            {
                objectRenderer.material.color = nandPlateColor;
            }
            else
            {
                objectRenderer.material.color = Color.white; // Default color if layer is not recognized
            }
        }
    }
}


        private void ResetObjectColor()
        {
            //Reset to the original color when the hover ends
            if (objectRenderer != null)
            {
                objectRenderer.material.color = originalColor;
            }
        }

        public void OnSelect(Transform currentTransform)
        {
            //No actions required for now
        }

        public void OnDeselect(Transform currentTransform)
        {
            //No actions required for now
        }
    }
}
