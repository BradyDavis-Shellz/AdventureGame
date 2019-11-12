using UnityEngine;
using System.Collections;

public interface IAudioSource
{
    AudioClip clip
    {
        get; set;
    }

    void PlayDelayed(float delay);
}
