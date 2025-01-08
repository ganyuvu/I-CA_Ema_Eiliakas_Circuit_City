using UnityEngine;

public class OpenORGate : MonoBehaviour
{
    [SerializeField] private ORGateManager gateManager;//Reference to the ORGateManager
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
        //Check if the gate should rise
        if (gateManager.GateActivated)
        {
            //Smoothly move the gate to the target Y position
            Vector3 targetPosition = new Vector3(initialPosition.x, targetYPosition, initialPosition.z);
            gate.position = Vector3.Lerp(gate.position, targetPosition, Time.deltaTime * speed);
        }
        else
        {
            //Smoothly return the gate to its initial position
            gate.position = Vector3.Lerp(gate.position, initialPosition, Time.deltaTime * speed);
        }
    }
}
