using UnityEngine;

namespace GD.Selection
{
    public class MouseRay : MonoBehaviour, IRayProvider
    {
        //Reference to the active camera (either main or secondary)
        //We need this as the raycast was previously only being created from the main camera
        [SerializeField] private Camera activeCamera;

        public Ray CreateRay()
        {
            //If no camera is assigned use main camera by default
            if (activeCamera == null)
            {
                activeCamera = Camera.main;
            }

            if (activeCamera != null)
            {
                //Create a ray from the mouse position on screen to the 3D world using the active camera
                Ray ray = activeCamera.ScreenPointToRay(Input.mousePosition);
                return ray;
            }
            else
            {
                Debug.LogError("No active camera found.");
                //Return default ray if no active camera is available
                return default;
            }
        }
    }
}
