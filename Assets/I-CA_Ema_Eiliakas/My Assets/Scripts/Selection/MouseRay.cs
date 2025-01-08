using UnityEngine;

namespace GD.Selection
{
    public class MouseRay : MonoBehaviour, IRayProvider
    {
        public Ray CreateRay()
        {
            //Create a ray from the mouse position on screen to the 3D world
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            return ray;
        }
    }
}
