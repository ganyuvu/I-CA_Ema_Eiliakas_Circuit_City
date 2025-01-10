using UnityEngine;

public class OpenGate : MonoBehaviour
{
    [SerializeField] public bool GateActivated;//Bool to check if the gate has been activated
    [SerializeField] private Transform gate;//The gate GameObject to move
    [SerializeField] private float targetYPosition = 5f;//Desired Y position for the gate
    [SerializeField] private float targetXPosition = 5f; //Desired X position for the trapdoor
    [SerializeField] private float speed = 2f;//Speed of gate movement

    private Vector3 initialPosition;//Initial position of the gate

    void Start()
    {
        //Store the gate's starting position
        initialPosition = gate.position;
    }

    void Update()
    {
        //Check which layer the gate is on
        if (gate.gameObject.layer == LayerMask.NameToLayer("Gate"))
        {
            //Handle movement for regular gate
            OpenGateVertically();
        }
        else if (gate.gameObject.layer == LayerMask.NameToLayer("TrapDoor"))
        {
            //Handle movement for trapdoor
            OpenTrapDoorHorizontally();
        }
    }

     //Method for opening a gate 
    private void OpenGateVertically()
    {
        if (GateActivated)
        {
            Vector3 targetPosition = new Vector3(initialPosition.x, targetYPosition, initialPosition.z);
            //Smoothly move the gate to the target position
            gate.position = Vector3.Lerp(gate.position, targetPosition, Time.deltaTime * speed);
        }
        else
        {
            //Smoothly return the gate to its initial position
            gate.position = Vector3.Lerp(gate.position, initialPosition, Time.deltaTime * speed);
        }
    }

    //Method for opening a trapdoor
    private void OpenTrapDoorHorizontally()
    {
        if (GateActivated)
        {
            Vector3 targetPosition = new Vector3(targetXPosition, initialPosition.y, initialPosition.z);
            //Smoothly move the trapdoor to the target position
            gate.position = Vector3.Lerp(gate.position, targetPosition, Time.deltaTime * speed);
        }
        else
        {
            //Smoothly return the trapdoor to its initial position
            gate.position = Vector3.Lerp(gate.position, initialPosition, Time.deltaTime * speed);
        }
    }
}
