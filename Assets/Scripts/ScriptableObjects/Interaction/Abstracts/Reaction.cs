using UnityEngine;

public abstract class Reaction : ScriptableObject, IReaction
{
    public void Init ()
    {
        SpecificInit ();
    }


    protected virtual void SpecificInit()
    {}


    public void React (MonoBehaviour monoBehaviour)
    {
        ImmediateReaction ();
    }


    protected abstract void ImmediateReaction ();
}
