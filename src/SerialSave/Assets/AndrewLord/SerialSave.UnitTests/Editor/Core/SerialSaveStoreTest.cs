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

    [Test]
    public void WhenGetAccessor_ThenAccessorForSpecifiedKeyProvided() {
      SaveKey<int> key = new SaveKey<int>("someKey");
      store.Load();
      store.SetValue(key, 100);

      SaveValueAccessor<int> accessor = store.GetAccessor(key);

      Assert.That(accessor.Get(), Is.EqualTo(100));
    }

    [Test]
    public void GivenTypedSaveKeyAndValuePresent_WhenGetValueTyped_ThenStoredValueReturned() {
      SaveKey<int> key0 = new SaveKey<int>("key0");
      Dictionary<string, object> expected = new Dictionary<string, object>();
      expected[key0.Name] = 100;
      persister.ReadData().Returns(expected);
      store.Load();

      int actual = store.GetValue(key0);

      Assert.That(actual, Is.EqualTo(100));
    }

    [Test]
    public void GivenTypedSaveKeyAndValueAbsent_WhenGetValueTyped_ThenDefaultForTypeReturned() {
      SaveKey<int> key0 = new SaveKey<int>("key0");
      persister.ReadData().Returns(new Dictionary<string, object>());
      store.Load();

      int actual = store.GetValue(key0);

      Assert.That(actual, Is.EqualTo(default(int)));
    }

    [Test]
    public void GivenDefaultProviderWithTypedSaveKeyAndValueAbsent_WhenGetValueTyped_ThenDefaultReturned() {
      DefaultValueProvider provider = Substitute.For<DefaultValueProvider>();
      store = new SerialSaveStore(persister, provider);
      SaveKey<int> key0 = new SaveKey<int>("key0");
      persister.ReadData().Returns(new Dictionary<string, object>());
      store.Load();
      int expectedDefault = 5005;
      provider.GetDefaultValue(key0.Name).Returns(expectedDefault);

      int actual = store.GetValue<int>(key0);

      Assert.That(actual, Is.EqualTo(expectedDefault));
    }

    [Test]
    public void GivenKeyAndValuePresent_WhenGetValueTyped_ThenStoredValueReturned() {
      string key0 = "key0";
      Dictionary<string, object> expected = new Dictionary<string, object>();
      expected[key0] = 100;
      persister.ReadData().Returns(expected);
      store.Load();

      int actual = store.GetValue<int>(key0);

      Assert.That(actual, Is.EqualTo(100));
    }

    [Test]
    public void GivenKeyAndValueAbsent_WhenGetValueTyped_ThenDefaultForTypeReturned() {
      string key0 = "key0";
      persister.ReadData().Returns(new Dictionary<string, object>());
      store.Load();

      int actual = store.GetValue<int>(key0);

      Assert.That(actual, Is.EqualTo(default(int)));
    }

    [Test]
    public void GivenDefaultProviderWithKeyAndValueAbsent_WhenGetValueTyped_ThenDefaultReturned() {
      DefaultValueProvider provider = Substitute.For<DefaultValueProvider>();
      store = new SerialSaveStore(persister, provider);
      string key0 = "key0";
      persister.ReadData().Returns(new Dictionary<string, object>());
      store.Load();
      int expectedDefault = 5005;
      provider.GetDefaultValue(key0).Returns(expectedDefault);

      int actual = store.GetValue<int>(key0);

      Assert.That(actual, Is.EqualTo(expectedDefault));
    }

    [Test]
    public void GivenKeyAndValuePresent_WhenGetValue_ThenStoredValueReturned() {
      string key0 = "key0";
      Dictionary<string, object> expected = new Dictionary<string, object>();
      expected[key0] = 100;
      persister.ReadData().Returns(expected);
      store.Load();

      object actual = store.GetValue(key0);

      Assert.That((int) actual, Is.EqualTo(100));
    }

    [Test]
    public void GivenKeyAndValueAbsent_WhenGetValue_ThenNullReturned() {
      string key0 = "key0";
      persister.ReadData().Returns(new Dictionary<string, object>());
      store.Load();

      object actual = store.GetValue(key0);

      Assert.That(actual, Is.EqualTo(null));
    }

    [Test]
    public void GivenDefaultProviderWithKeyAndValueAbsent_WhenGetValue_ThenDefaultReturned() {
      DefaultValueProvider provider = Substitute.For<DefaultValueProvider>();
      store = new SerialSaveStore(persister, provider);
      string key0 = "key0";
      persister.ReadData().Returns(new Dictionary<string, object>());
      store.Load();
      string expectedDefault = "someMagicDefault";
      provider.GetDefaultValue(key0).Returns(expectedDefault);

      object actual = store.GetValue(key0);

      Assert.That(actual, Is.EqualTo(expectedDefault));
    }

    [Test]
    public void GivenTypedKeyAndValueAbsent_WhenSetValue_ThenValueStored() {
      SaveKey<bool> key0 = new SaveKey<bool>("key0");
      persister.ReadData().Returns(new Dictionary<string, object>());
      store.Load();

      store.SetValue(key0, true);

      Assert.That(store.GetValue(key0), Is.True);
    }

    [Test]
    public void GivenTypedKeyAndValuePresent_WhenSetValue_ThenValueOverwritten() {
      SaveKey<bool> key0 = new SaveKey<bool>("key0");
      Dictionary<string, object> expected = new Dictionary<string, object>();
      expected[key0.Name] = true;
      persister.ReadData().Returns(expected);
      store.Load();

      store.SetValue(key0, false);

      Assert.That(store.GetValue(key0), Is.False);
    }

    [Test]
    public void GivenKeyAndValueAbsent_WhenSetValue_ThenValueStored() {
      string key0 = "key0";
      persister.ReadData().Returns(new Dictionary<string, object>());
      store.Load();

      store.SetValue(key0, true);

      Assert.That(store.GetValue(key0), Is.True);
    }

    [Test]
    public void GivenKeyAndValuePresent_WhenSetValue_ThenValueOverwritten() {
      string key0 = "key0";
      Dictionary<string, object> expected = new Dictionary<string, object>();
      expected[key0] = true;
      persister.ReadData().Returns(expected);
      store.Load();

      store.SetValue(key0, false);

      Assert.That(store.GetValue(key0), Is.False);
    }

    [Test]
    public void GivenTypedKeyAndValuePresent_WhenHasValue_ThenTrue() {
      SaveKey<long> key0 = new SaveKey<long>("key0");
      Dictionary<string, object> expected = new Dictionary<string, object>();
      expected[key0.Name] = 200L;
      persister.ReadData().Returns(expected);
      store.Load();

      bool actual = store.HasValue(key0);

      Assert.That(actual, Is.True);
    }

    [Test]
    public void GivenTypedKeyAndValueAbsent_WhenHasValue_ThenFalse() {
      SaveKey<long> key0 = new SaveKey<long>("key0");
      persister.ReadData().Returns(new Dictionary<string, object>());
      store.Load();

      bool actual = store.HasValue(key0);

      Assert.That(actual, Is.False);
    }

    [Test]
    public void GivenKeyAndValuePresent_WhenHasValue_ThenTrue() {
      string key0 = "key0";
      Dictionary<string, object> expected = new Dictionary<string, object>();
      expected[key0] = 200L;
      persister.ReadData().Returns(expected);
      store.Load();

      bool actual = store.HasValue(key0);

      Assert.That(actual, Is.True);
    }

    [Test]
    public void GivenKeyAndValueAbsent_WhenHasValue_ThenFalse() {
      string key0 = "key0";
      persister.ReadData().Returns(new Dictionary<string, object>());
      store.Load();

      bool actual = store.HasValue(key0);

      Assert.That(actual, Is.False);
    }

  }
}