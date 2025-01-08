using UnityEngine;

public class OpenGate : MonoBehaviour
{
    [SerializeField] public bool GateActivated;//Bool to check if the gate has been activated
    [SerializeField] private Transform gate;//The gate GameObject to move
    [SerializeField] private float targetYPosition = 5f;//Desired Y position for the gate
    [SerializeField] private float speed = 2f;//Speed of gate movement

    private Vector3 initialPosition;//Initial position of the gate

    void Start()
    {
        //Store the gate's starting position
        initialPosition = gate.position;
    }

    void Update()
    {
        //Check if the gate should rise based on the GateActivated status
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
}
