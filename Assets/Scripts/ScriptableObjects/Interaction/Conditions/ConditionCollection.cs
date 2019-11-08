using UnityEngine;

public class ConditionCollection : ScriptableObject
{
    public string description;
    public Condition[] requiredConditions = new Condition[0];
    public IReactionCollection reactionCollection;


    public bool CheckAndReact()
    {
        for (int i = 0; i < requiredConditions.Length; i++)
        {
            if (!AllConditions.Instance.CheckCondition (requiredConditions[i]))
                return false;
        }

        if(reactionCollection != null)
            reactionCollection.React();

        return true;
    }
}