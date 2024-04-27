using UnityEngine;

public class PlayAudioOnProximity : MonoBehaviour
{
    public float proximityDistance = 5f; // Distance at which the audio starts playing
    public AudioSource audioSource; // The AudioSource component on this GameObject

    private bool playerInRange;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            PlayAudio();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            StopAudio();
        }
    }

    private void Update()
    {
        if (playerInRange)
        {
            float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
            if (distance > proximityDistance)
            {
                playerInRange = false;
                StopAudio();
            }
        }
    }

    private void PlayAudio()
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    private void StopAudio()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}