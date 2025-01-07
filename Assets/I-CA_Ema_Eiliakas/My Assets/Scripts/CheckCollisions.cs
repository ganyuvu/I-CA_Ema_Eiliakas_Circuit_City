using UnityEngine;

public class CheckCollision : MonoBehaviour
{
    public bool isColliding; //Bool to check if something is colliding

    private void OnCollisionEnter(Collision collision)
    {
        //Check if the object that collided is the player or a box
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Box"))
        {
            isColliding = true;
            Debug.Log("Pressure Plate is being pressed");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        //When the object stops colliding
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Box"))
        {
            isColliding = false;
            Debug.Log("Pressure Plate is released");
        }
    }
}
