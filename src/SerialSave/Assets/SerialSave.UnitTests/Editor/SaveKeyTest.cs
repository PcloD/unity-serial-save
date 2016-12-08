namespace AndrewLord.UnitySerialSave.UnitTests {

  using NUnit.Framework;

  public class SaveKeyTest {

    [Test]
    public void WhenName_ThenProvidedNameReturned() {
      string expected = "someKey";
      SaveKey<string> key = new SaveKey<string>(expected);

      string actual = key.Name;

      Assert.That(actual, Is.EqualTo(expected));
    }
  }
}