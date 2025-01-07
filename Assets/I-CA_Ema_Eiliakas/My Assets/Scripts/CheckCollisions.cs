using UnityEngine;

public class CheckCollision : MonoBehaviour
{
    public bool isColliding;//Bool to check if something is colliding

    private void OnTriggerEnter(Collider other)
    {
        //Check if the object that entered the trigger is the player or a Box
        if (other.CompareTag("Player") || other.CompareTag("Box"))
        {
            isColliding = true;
            Debug.Log("Pressure Plate is being pressed");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //When the objects exits the trigger
        if (other.CompareTag("Player") || other.CompareTag("Box"))
        {
            isColliding = false;
            Debug.Log("Pressure Plate is released");
        }
    }
}
