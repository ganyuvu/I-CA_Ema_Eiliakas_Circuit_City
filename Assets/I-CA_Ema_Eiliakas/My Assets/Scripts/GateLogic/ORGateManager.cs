using UnityEngine;

public class ORGateManager : MonoBehaviour
{
    [SerializeField] private CheckCollision pressurePlate1;
    [SerializeField] private CheckCollision pressurePlate2;

    public bool GateActivated = false;
    private bool hasPlayedSound = false;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Update()
    {
        //Perform OR logic: At least one pressure plate must be pressed
        if (pressurePlate1.isColliding || pressurePlate2.isColliding)
        {
            GateActivated = true;
            if (!hasPlayedSound)
            {
                PlayOpenGateSFX();
                hasPlayedSound = true;
            }
            Debug.Log("OR Gate Open: At least one pressure plate is pressed.");
        }
        else
        {
            GateActivated = false;
        }
    }

    //Method to play SFX
    private void PlayOpenGateSFX()
    {
        audioManager.PlaySFX(audioManager.gateOpen);
    }
}
