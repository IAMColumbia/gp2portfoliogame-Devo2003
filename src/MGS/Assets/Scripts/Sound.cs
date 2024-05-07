using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioClip[] soundClips;

    private AudioSource audioSource;

    void Awake()
    {
        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();

        // Check if there are any sound clips assigned
        if (soundClips != null && soundClips.Length > 0)
        {
            // Choose a random sound clip from the array
            AudioClip randomClip = soundClips[Random.Range(0, soundClips.Length)];

            // Play the chosen sound clip
            audioSource.clip = randomClip;
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("No sound clips assigned to play!");
        }
    }
}
