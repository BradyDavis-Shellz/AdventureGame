using UnityEngine;
using System.Collections;

public class AudioSourceWrapper : IAudioSource
{
    private AudioSource audioSource;

    public AudioSourceWrapper(AudioSource audioSource)
    {
        this.audioSource = audioSource;
    }

    public AudioClip clip { get => audioSource.clip; set => audioSource.clip = value; }

    public void PlayDelayed(float delay)
    {
        audioSource.PlayDelayed(delay);
    }
}
