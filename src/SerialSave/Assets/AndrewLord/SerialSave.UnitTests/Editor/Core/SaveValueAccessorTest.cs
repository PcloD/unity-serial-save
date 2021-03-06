//
// Copyright (C) 2016 Andrew Lord
//
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with
// the License.
//
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on
// an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and limitations under the License.
//
namespace AndrewLord.UnitySerialSave.UnitTests {

  using NSubstitute;
  using NUnit.Framework;

  public class SaveValueAccessorTest {

    private Persister persister;
    private SerialSaveStore store;

    [SetUp]
    public void SetUp() {
      persister = Substitute.For<Persister>();
      store = new SerialSaveStore(persister);
      store.Load();
    }

    [Test]
    public void WhenGet_ThenValueRetrievedFromSaveStore() {
      SaveKey<int> key = new SaveKey<int>("someKey");
      store.SetValue(key, 10);
      SaveValueAccessor<int> accessor = store.GetAccessor(key);

      int actual = accessor.Get();

      Assert.That(actual, Is.EqualTo(10));
    }

    [Test]
    public void WhenSet_ThenValueSetInSaveStore() {
      SaveKey<string> key = new SaveKey<string>("someKey");
      SaveValueAccessor<string> accessor = store.GetAccessor(key);

      accessor.Set("newValue");

      Assert.That(store.GetValue(key), Is.EqualTo("newValue"));
    }

    [Test]
    public void WhenSet_ThenValueChangedEventFired() {
      float retrievedValue = -1f;
      SaveKey<float> key = new SaveKey<float>("someKey");
      SaveValueAccessor<float> accessor = store.GetAccessor(key);
      accessor.ValueChanged += (saveValue) => retrievedValue = saveValue;

      accessor.Set(100f);

      Assert.That(retrievedValue, Is.EqualTo(100f));
    }

    [Test]
    public void WhenSetSave_ThenValueSetInSaveStore() {
      SaveKey<string> key = new SaveKey<string>("someKey");
      SaveValueAccessor<string> accessor = store.GetAccessor(key);

      accessor.SetSave("newValue");

      Assert.That(store.GetValue(key), Is.EqualTo("newValue"));
    }

    [Test]
    public void WhenSetSave_ThenValueChangedEventFired() {
      float retrievedValue = -1f;
      SaveKey<float> key = new SaveKey<float>("someKey");
      SaveValueAccessor<float> accessor = store.GetAccessor(key);
      accessor.ValueChanged += (saveValue) => retrievedValue = saveValue;

      accessor.SetSave(100f);

      Assert.That(retrievedValue, Is.EqualTo(100f));
    }

    [Test]
    public void WhenSetSave_ThenStoreSaved() {
      SaveKey<int> key = new SaveKey<int>("someKey");
      SaveValueAccessor<int> accessor = store.GetAccessor(key);

      accessor.SetSave(55);

      persister.Received(1).SaveData(Arg.Any<object>());
    }

    [Test]
    public void WhenSave_ThenStoreSaved() {
      SaveKey<int> key = new SaveKey<int>("someKey");
      SaveValueAccessor<int> accessor = store.GetAccessor(key);

      accessor.Save();

      persister.Received(1).SaveData(Arg.Any<object>());
    }
  }
}
