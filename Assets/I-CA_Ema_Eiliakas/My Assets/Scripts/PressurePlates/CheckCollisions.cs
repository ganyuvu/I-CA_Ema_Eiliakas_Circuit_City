using UnityEngine;

public class CheckCollision : MonoBehaviour
{
    public bool isColliding;//Bool to check if something is colliding
    private int collisionCount = 0;//Counter to track how many objects are colliding

    private void OnCollisionEnter(Collision collision)
    {
        //Check if the object that collided is the player or a box
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Box"))
        {
            //Increment counter for each new collision
            //This is so that if multiple objects are on a pressure plate and one object gets taken off
            //It doesn't accidentally set the bool to false
            collisionCount++;
            if (collisionCount > 0)
            {
                //Set to true when at least one object is colliding
                isColliding = true;
                Debug.Log("Pressure Plate is being pressed");
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        //When the object stops colliding
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Box"))
        {
            //Decrement counter when an object exits the collision
            collisionCount--; 
            if (collisionCount <= 0)
            {
                //Set to false when no objects are colliding
                isColliding = false;
                Debug.Log("Pressure Plate is released");
            }
        }
    }
}
