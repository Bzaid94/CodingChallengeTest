using CodingChallenge;

namespace CodingChallengeTest;

using NUnit.Framework;

[TestFixture]
public class OldPhonePadTests
{
    private OldPhonePad oldPhonePad;

    [SetUp]
    public void Setup()
    {
        oldPhonePad = new OldPhonePad();
    }

    [Test]
    public void TestSingleLetter()
    {
        Assert.AreEqual("E", oldPhonePad.ConvertToText("33#"));
    }

    [Test]
    public void TestBackspace()
    {
        Assert.AreEqual("B", oldPhonePad.ConvertToText("227*#"));
    }

    [Test]
    public void TestMultiLetterWord()
    {
        Assert.AreEqual("HELLO", oldPhonePad.ConvertToText("4433555 555666#"));
    }
    
    [Test]
    public void TestInvalidCharacterThrowsException()
    {
        Assert.Throws<ArgumentException>(() => oldPhonePad.ConvertToText("asF12Z3#"));
    }
    
    [Test]
    public void TestNoEndCharacter()
    {
        var oldPhonePad = new OldPhonePad();
        var ex = Assert.Throws<ArgumentException>(() => oldPhonePad.ConvertToText("33"));
        Assert.That(ex.Message, Is.EqualTo("End character '#' not found in input."));
    }

    [Test]
    public void TestNonNumericCharacters()
    {
        OldPhonePad oldPhonePad = new OldPhonePad();
        Assert.Throws<ArgumentException>(() => oldPhonePad.ConvertToText("abc#"));
    }

    [Test]
    public void TestMultipleSpaces()
    {
        OldPhonePad oldPhonePad = new OldPhonePad();
        Assert.AreEqual("AA", oldPhonePad.ConvertToText("2 2#"));
    }

    [Test]
    public void TestMultipleBackspaces()
    {
        OldPhonePad oldPhonePad = new OldPhonePad();
        Assert.AreEqual("", oldPhonePad.ConvertToText("2* *#"));
    }

}
