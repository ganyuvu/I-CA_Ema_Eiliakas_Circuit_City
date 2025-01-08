using UnityEngine;

public class RayCastDetection : MonoBehaviour
{
    //The maximum distance the ray will detect objects
    [SerializeField] private float detectionRange = 5f;

    //LayerMask to filter what the ray can hit (optional)
    [SerializeField] private LayerMask layerMask;

    //Bool to check if the player is facing an object
    public bool isFacingObject { get; private set; }
    public GameObject currentObject { get; private set; }

    //Offset to modify the starting point of the ray
    [SerializeField] private Vector3 raycastOffset = new Vector3(0f, 0f, 0.5f);

    void Update()
    {
        CheckForObjectWithRaycast();
    }

    //Method to check for objects in front of the player using Raycast
    void CheckForObjectWithRaycast()
    {
        //Cast a ray from the player's position with the specified offset
        RaycastHit hit;

        //Cast the ray and check if it hits anything
        if (Physics.Raycast(transform.position + raycastOffset, transform.forward, out hit, detectionRange, layerMask))
        {
            //Object detected
            isFacingObject = true;
            currentObject = hit.collider.gameObject;

            //Log the name of the object
            //Debug.Log("Object detected: " + currentObject.name);

            //Draw a debug line in the scene view
            Debug.DrawLine(transform.position + raycastOffset, hit.point, Color.green);
        }
        else
        {
            //No object detected
            isFacingObject = false;
            currentObject = null;

            //Log that no object was detected
            //Debug.Log("No object detected in front.");
        }
    }

    //Draw the ray
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position + raycastOffset, transform.position + raycastOffset + transform.forward * detectionRange);
    }
}
