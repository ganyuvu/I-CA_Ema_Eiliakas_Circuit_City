using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Collectible : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI collectibleCounterText;

    //Counter shared among all collectibles
    private static int collectibleCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        //Check if the player collided with the collectible
        if (other.CompareTag("Player"))
        {
            Collect();
        }
    }

    private void Collect()
    {
        //Increment the counter
        collectibleCount++;

        //Update the UI
        if (collectibleCounterText != null)
        {
            collectibleCounterText.text = $"Collectibles: {collectibleCount}";
        }
        else
        {
            Debug.LogWarning("Collectible counter text is not assigned.");
        }

        //Destroy the collectible object
        Destroy(gameObject);
    }
}
