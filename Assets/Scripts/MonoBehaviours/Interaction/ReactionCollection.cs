using UnityEngine;

public class ReactionCollection : MonoBehaviour, IReactionCollection
{
    public IReaction[] reactions = new Reaction[0];

    public void SetReactions(IReaction[] reactions)
    {
        this.reactions = reactions;
    }


    private void Start ()
    {
        for (int i = 0; i < reactions.Length; i++)
        {
            DelayedReaction delayedReaction = reactions[i] as DelayedReaction;

            if (delayedReaction)
                delayedReaction.Init ();
            else
                reactions[i].Init ();
        }
    }


    public void React ()
    {
        for (int i = 0; i < reactions.Length; i++)
        {
            DelayedReaction delayedReaction = reactions[i] as DelayedReaction;

            if(delayedReaction)
                delayedReaction.React (this);
            else
                reactions[i].React (this);
        }
    }
}
