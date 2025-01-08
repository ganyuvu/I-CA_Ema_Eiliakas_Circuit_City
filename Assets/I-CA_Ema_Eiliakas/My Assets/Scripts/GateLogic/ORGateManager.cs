using UnityEngine;

public class ORGateManager : MonoBehaviour
{
    [SerializeField] private CheckCollision pressurePlate1;//Reference to CheckCollision script of pressure plate 1
    [SerializeField] private CheckCollision pressurePlate2;//Reference to CheckCollision script of pressure plate 2
    [SerializeField] private OpenGate gateController;//Reference to OpenGate script

    private bool hasPlayedSound = false;//Bool to check if the SFX has been played

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Update()
    {
        //Perform OR logic check
        //If either pressure plate is pressed, activate the gate
        bool isGateActivated = pressurePlate1.isColliding || pressurePlate2.isColliding;

        //Pass the status to OpenGate script
        gateController.GateActivated = isGateActivated;

        if (isGateActivated && !hasPlayedSound)
        {
            PlayOpenGateSFX();
            hasPlayedSound = true;
        }
        else if (!isGateActivated && hasPlayedSound)
        {
            //Reset SFX bool when the gate is closed
            hasPlayedSound = false;
        }
    }

    //Method to play SFX
    private void PlayOpenGateSFX()
    {
        audioManager.PlaySFX(audioManager.gateOpen);
    }
}
