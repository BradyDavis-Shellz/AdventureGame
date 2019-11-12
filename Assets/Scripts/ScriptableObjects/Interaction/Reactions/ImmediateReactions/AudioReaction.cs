using UnityEngine;

public class AudioReaction : Reaction
{
    public AudioSource audioSource;
    public IAudioSource audioSourceWrapper;
    public AudioClip audioClip;
    public float delay;

    private AudioSourceWrapperFactory audioSourceWrapperFactory;

    public AudioReaction()
    {
        audioSourceWrapperFactory = new AudioSourceWrapperFactory();
    }

    public AudioReaction(AudioSourceWrapperFactory audioSourceWrapperFactory)
    {
        this.audioSourceWrapperFactory = audioSourceWrapperFactory;
    }

    protected override void ImmediateReaction()
    {
        if(audioSourceWrapper == null)
        {
            audioSourceWrapper = audioSourceWrapperFactory.Create(audioSource);
        }
        
        audioSourceWrapper.clip = audioClip;
        audioSourceWrapper.PlayDelayed(delay);
    }
}