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
namespace AndrewLord.UnitySerialSaveSample {

  using AndrewLord.UnitySerialSave;
  using UnityEngine;
  using UnityEngine.UI;

  public class CounterLabel : MonoBehaviour {

    public SaveDataStore saveDataStore;
    public Text label;

    private SerialSaveStore saveStore;

    void Start() {
      saveStore = saveDataStore.SaveStore;
      saveStore.ValueChanged += CounterValueChanged;
      saveStore.StoreLoaded += StoreLoaded;
    }

    private void StoreLoaded() {
      CounterValueChanged(SaveDataStore.keyCounter.Name);
      saveStore.StoreLoaded -= StoreLoaded;
    }

    private void CounterValueChanged(string keyName) {
      if (keyName.Equals(SaveDataStore.keyCounter.Name)) {
        int counter = saveStore.GetValue<int>(keyName);
        label.text = counter.ToString();
      }
    }
  }
}
