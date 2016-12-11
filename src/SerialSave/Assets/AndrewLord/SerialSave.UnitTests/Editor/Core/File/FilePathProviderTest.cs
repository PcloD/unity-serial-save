namespace AndrewLord.UnitySerialSave.UnitTests {

  using NUnit.Framework;
  using UnityEngine;

  public class FilePathProviderTest {

    private const string Filename = "somefile";

    private FilePathProvider provider;

    [SetUp]
    public void SetUp() {
      provider = new FilePathProvider(Filename);
    }

    [Test]
    public void WhenFilePath_ThenFilePathReturned() {
      string expected = Application.persistentDataPath + "/" + Filename + ".dat";

      string actual = provider.FilePath;

      Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void WhenTempFilePath_ThenTempFilePathReturned() {
      string expected = Application.persistentDataPath + "/" + Filename + ".dat.temp";

      string actual = provider.TempFilePath;

      Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void WhenBackupFilePath_ThenBackupFilePathReturned() {
      string expected = Application.persistentDataPath + "/" + Filename + ".dat.backup";

      string actual = provider.BackupFilePath;

      Assert.That(actual, Is.EqualTo(expected));
    }
  }
}