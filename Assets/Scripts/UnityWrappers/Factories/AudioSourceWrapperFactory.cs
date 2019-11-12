using UnityEngine;
using System.Collections;

public class AudioSourceWrapperFactory
{
    public virtual IAudioSource Create(AudioSource audioSource)
    {
        return new AudioSourceWrapper(audioSource);
    }
}
