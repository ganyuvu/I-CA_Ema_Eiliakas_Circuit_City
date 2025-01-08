using UnityEngine;

public class RayCastDetection : MonoBehaviour
{
    //The maximum distance the sphere will detect objects
    [SerializeField] private float detectionRange = 2f;

    //LayerMask to filter what the sphere can hit
    [SerializeField] private LayerMask layerMask;

    //Bool to check if the player is facing an object
    public bool isFacingObject { get; private set; }
    public GameObject currentObject { get; private set; }

    //Offset to modify the starting point of the sphere
    [SerializeField] private Vector3 raycastOffset = new Vector3(0f, 0f, 0.5f);

    void Update()
    {
        CheckForObjectWithSphere();
    }

    //Method to check for objects in front of the player using OverlapSphere
    void CheckForObjectWithSphere()
    {
        //Cast a sphere from the player's position with the specified offset and player's forward rotation
        Collider[] hitColliders = Physics.OverlapSphere(transform.position + transform.TransformDirection(raycastOffset), detectionRange, layerMask);

        if (hitColliders.Length > 0)
        {
            isFacingObject = true;
            //Use the first object detected as to not detect multiple
            currentObject = hitColliders[0].gameObject;
        }
        else
        {
            isFacingObject = false;
            currentObject = null;
        }
    }

    //Draw the sphere in the scene view
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        //Draw the sphere with the transformed offset to reflect the player's rotation
        Gizmos.DrawWireSphere(transform.position + transform.TransformDirection(raycastOffset), detectionRange);
    }
}
