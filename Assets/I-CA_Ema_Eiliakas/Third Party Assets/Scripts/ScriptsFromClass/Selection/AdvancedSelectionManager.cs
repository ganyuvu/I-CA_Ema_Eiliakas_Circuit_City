using UnityEngine;

namespace GD.Selection
{
    public class AdvancedSelectionManager : MonoBehaviour
    {
        private IRayProvider rayProvider;
        private ISelector selector;
        private ISelectionResponse response;
        private Transform currentSelection;

        private void Awake()
        {
            //Find components attached to the same GameObject (SelectionManager)
            rayProvider = GetComponent<IRayProvider>();
            selector = GetComponent<ISelector>();
            response = GetComponent<ISelectionResponse>();

            //If they're not found, log an error
            if (rayProvider == null) 
                Debug.LogError("RayProvider is missing!");
            if (selector == null) 
                Debug.LogError("Selector is missing!");
            if (response == null) 
                Debug.LogError("Response is missing!");
        }

        private void Update()
        {
            if (currentSelection != null)
                response.OnDeselect(currentSelection);

            selector.Check(rayProvider.CreateRay());

            currentSelection = selector.GetSelection();

            if (currentSelection != null)
                response.OnSelect(currentSelection);
        }
    }
}
