using NSubstitute;
using NUnit.Framework;

[TestFixture]
public class ConditionReactionTests
{
    ConditionReaction sut;
    Condition condition;

    [SetUp]
    public void SetUp()
    {
        sut = new ConditionReaction();
        Condition condition = new Condition();
        condition.satisfied = false;
        sut.condition = condition;
        sut.satisfied = true;
    }

    [Test]
    public void TestThatImmediateReactionSetsConditionSatisfiedToConditionReactionSatisfied()
    {
        sut.React(null);

        Assert.AreEqual(sut.condition.satisfied, sut.satisfied);
    }
}
