using UnityEngine;

public class ANDGateManager : MonoBehaviour
{
    [SerializeField] private CheckCollision pressurePlate1;//Reference to CheckCollision script of pressure plate 1
    [SerializeField] private CheckCollision pressurePlate2;//Reference to CheckCollision script of pressure plate 2

    public bool GateActivated = false;//Bool to check if the gate has been activated

    void Update()
    {
        //Perform AND logic check
        //Both pressure plates must be checked
        if (pressurePlate1.isColliding && pressurePlate2.isColliding)
        {
            GateActivated = true;
            Debug.Log("Both pressure plates are pressed. Logic Gate Open!");
        }
        else
        {
            GateActivated = false;
            Debug.Log("Logic Gate is Closed");
        }
    }
}
