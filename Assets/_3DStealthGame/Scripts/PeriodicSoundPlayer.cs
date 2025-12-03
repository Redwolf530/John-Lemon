using UnityEngine;

public class PeriodicSoundPlayer : MonoBehaviour
{
  

    public AudioClip soundToPlay; // The audio clip to play
    public float playInterval = 5f; // Time in seconds between plays
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component not found on this GameObject!");
            enabled = false; // Disable the script if no AudioSource
            return;
        }

        // Assign the sound to the AudioSource
        audioSource.clip = soundToPlay;

        // Start the coroutine to play the sound periodically
        StartCoroutine(PlaySoundPeriodically());
    }

    private System.Collections.IEnumerator PlaySoundPeriodically()
    {
        while (true) // Loop indefinitely
        {
            audioSource.Play();
            yield return new WaitForSeconds(playInterval); // Wait for the specified interval
        }
    }
}
