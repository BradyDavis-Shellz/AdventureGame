using UnityEngine;
using System.Collections;
using NUnit.Framework;
using NSubstitute;

public class TextReactionTests
{
    TextReaction sut;

    TextManager manager;
    ITextManager textManager;

    [SetUp]
    public void SetUp()
    {
        var emptyObject = new GameObject();

        textManager = Substitute.For<ITextManager>();

        manager = emptyObject.AddComponent<TextManager>();
        
        sut = ScriptableObject.CreateInstance<TextReaction>();

        sut.message = "message";
        sut.textColor = Color.black;
        sut.delay = 1f;
        sut.Init();

        sut.SetTextManager(textManager);
    }

    [Test]
    public void TestThatImmediateReactionCallsTextManagerToDisplayWithText()
    {
        sut.React(manager);

        textManager.Received().DisplayMessage(sut.message, sut.textColor, sut.delay);
    }
}
