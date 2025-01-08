using UnityEngine;

namespace GD.Selection
{
    public class MouseSelection : MonoBehaviour, ISelector
    {
        private RaycastHit hitInfo;

        public void Check(Ray ray)
        {
            //Perform raycast to detect objects under the mouse
            if (Physics.Raycast(ray, out hitInfo))
            {
                //Debug.Log("Hit: " + hitInfo.transform.name);
            }
        }

        public Transform GetSelection()
        {
            //Return the transform of the object hit by the ray, or null if nothing was hit
            return hitInfo.transform;
        }

        public RaycastHit GetHitInfo()
        {
            return hitInfo;
        }
    }
}
