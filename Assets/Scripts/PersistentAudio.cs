using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentAudio : MonoBehaviour
{
    private static PersistentAudio instance; // Singleton instance

    private void Awake()
    {
        // Singleton pattern to ensure only one instance exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Make this GameObject persist
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
            return; // Important to prevent further execution in this instance
        }
    }

    // Example usage (you might have other methods to control the audio)
    public void PlaySound(AudioClip clip)
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null && clip != null && audioSource.isPlaying == false)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
        else
        {
            Debug.LogError("AudioSource or AudioClip is missing!");
        }
    }
   
    public void StopSound()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null && audioSource.isPlaying == true)
        {
            audioSource.Stop();
        }
    }
}