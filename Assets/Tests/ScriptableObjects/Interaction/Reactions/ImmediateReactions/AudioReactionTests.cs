using UnityEngine;
using NSubstitute;
using NUnit.Framework;
[TestFixture]
public class AudioReactionTests
{
    AudioReaction sut;
    IAudioSource audioSourceWrapper;

    AudioSourceWrapperFactory factory;
    AudioSource audioSource;
    AudioClip clip;
    float delay;

    [SetUp]
    public void SetUp()
    {
        audioSourceWrapper = Substitute.For<IAudioSource>();
        factory = Substitute.For<AudioSourceWrapperFactory>();
        factory.Create(Arg.Any<AudioSource>()).Returns(audioSourceWrapper);

        sut = new AudioReaction(factory);
        clip = AudioClip.Create("MarketAmbient", 1, 1, 1000, false);
        sut.audioClip = clip;
    }

    [TearDown]
    public void TearDown()
    {
    }

    [Test]
    public void TestThatImmediateReactionSetsAudioClipAndPlaysWithDelay()
    {
        sut.React(null);

        audioSourceWrapper.Received().clip = clip;
        audioSourceWrapper.Received().PlayDelayed(delay);
    }
}
