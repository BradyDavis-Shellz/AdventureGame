using UnityEngine;

public abstract class Reaction : ScriptableObject
{
    public virtual void Init ()
    {
        SpecificInit ();
    }


    protected virtual void SpecificInit()
    {}


    public virtual void React (MonoBehaviour monoBehaviour)
    {
        ImmediateReaction ();
    }


    protected abstract void ImmediateReaction ();
}
