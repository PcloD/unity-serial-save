namespace AndrewLord.UnitySerialSave.UnitTests {

  using System.Collections.Generic;
  using NSubstitute;
  using NUnit.Framework;

  public class SerialSaveStoreTest {

    private const string TestFile = "testfile";

    private Persister persister;
    private SerialSaveStore store;

    [SetUp]
    public void SetUp() {
      persister = Substitute.For<Persister>();
      store = new SerialSaveStore(persister);
    }

    [Test]
    public void GivenData_WhenLoad_ThenDataLoaded() {
      Dictionary<string, object> expected = new Dictionary<string, object>();
      expected["key0"] = 100;
      expected["key1"] = "someValue";
      persister.ReadData().Returns(expected);

      store.Load();

      Assert.That(store.GetValue<int>("key0"), Is.EqualTo(100));
      Assert.That(store.GetValue<string>("key1"), Is.EqualTo("someValue"));
    }

    [Test]
    public void GivenNoData_WhenLoad_ThenEmptyDictionary() {
      store.Load();

      Assert.That(store.HasValue("key0"), Is.False);
      Assert.That(store.HasValue("key1"), Is.False);
    }

    [Test]
    public void WhenLoad_ThenStoreLoadedEventFired() {
      bool loaded = false;
      store.StoreLoaded += () => loaded = true;

      store.Load();

      Assert.That(loaded, Is.True);
    }

    [Test]
    public void GivenDataLoaded_WhenLoaded_ThenTrue() {
      store.Load();

      Assert.That(store.Loaded, Is.True);
    }

    [Test]
    public void GivenDataNotLoaded_WhenLoaded_ThenFalse() {
      Assert.That(store.Loaded, Is.False);
    }

    [Test]
    public void WhenSave_ThenDataSaved() {
      Dictionary<string, object> expected = new Dictionary<string, object>();
      expected["key0"] = 100;
      expected["key1"] = "someValue";
      persister.ReadData().Returns(expected);
      store.Load();

      store.Save();

      persister.Received(1).SaveData(expected);
    }

    [Test]
    public void WhenSave_ThenStoreSavedEventFired() {
      bool saved = false;
      store.StoreSaved += () => saved = true;

      store.Save();

      Assert.That(saved, Is.True);
    }

  }
}