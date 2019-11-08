using UnityEngine;
using System.Collections;

public abstract class DelayedReaction : Reaction
{
    public float delay;


    protected WaitForSeconds wait;


    public new virtual void Init ()
    {
        wait = new WaitForSeconds (delay);

        SpecificInit ();
    }


    public new virtual void React (MonoBehaviour monoBehaviour)
    {
        monoBehaviour.StartCoroutine (ReactCoroutine ());
    }


    protected IEnumerator ReactCoroutine ()
    {
        yield return wait;

        ImmediateReaction ();
    }
}
