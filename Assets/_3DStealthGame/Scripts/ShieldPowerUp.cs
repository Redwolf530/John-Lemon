using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
{
    public AudioSource pickupAudio; // Optional: assign a pickup sound

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("ShieldPowerUp: Something collided! Object name: " + other.gameObject.name);

        // Check if the player picked up the shield
        PlayerShield playerShield = other.GetComponent<PlayerShield>();

        if (playerShield != null)
        {
            Debug.Log("ShieldPowerUp: PlayerShield found! Activating shield...");

            // Activate the shield
            playerShield.ActivateShield();

            Debug.Log("ShieldPowerUp: Shield activated! HasShield = " + playerShield.HasShield);

            // Play pickup sound if assigned
            if (pickupAudio != null)
            {
                pickupAudio.Play();
            }

            // Destroy the power-up object
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("ShieldPowerUp: PlayerShield component NOT found on " + other.gameObject.name);
        }
    }
}
