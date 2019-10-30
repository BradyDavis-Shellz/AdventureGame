using UnityEngine;
using System.Collections;
using NUnit.Framework;
using NSubstitute;

public class ConditionCollectionTests
{
    ConditionCollection sut;

    AllConditions allConditions;
    IReactionCollection reactionCollection;

    [SetUp] 
    public void SetUp()
    {
        sut = ScriptableObject.CreateInstance<ConditionCollection>();

        allConditions = Substitute.For<AllConditions>();
        AllConditions.Instance = allConditions;
        reactionCollection = Substitute.For<IReactionCollection>();
        sut.reactionCollection = reactionCollection;
    }

    [Test]
    public void CheckAndReactWhereHasNoConditionsReturnsTrue()
    {
        allConditions.CheckCondition(default).ReturnsForAnyArgs(false);
        Assert.IsTrue(sut.CheckAndReact());
    }

    [Test]
    public void CheckAndReactWhereAllConditionsCheckConditionsReturnsFalseReturnsFalse()
    {
        sut.requiredConditions = new Condition[] { new Condition() };
        allConditions.CheckCondition(Arg.Any<Condition>()).Returns(false);
        Assert.IsFalse(sut.CheckAndReact());
    }

    [Test]
    public void CheckAndReactWhereCheckConditionRetursTrueShouldReactOnReactCollection()
    {
        sut.requiredConditions = new Condition[] { new Condition() };
        allConditions.CheckCondition(Arg.Any<Condition>()).Returns(true);
        Assert.IsTrue(sut.CheckAndReact());

        sut.reactionCollection.Received().React();
    }
}
