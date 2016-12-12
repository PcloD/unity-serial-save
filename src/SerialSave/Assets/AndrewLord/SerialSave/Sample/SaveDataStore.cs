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

  public class SaveDataStore : MonoBehaviour {

    private const string filename = "mydata";

    public static readonly SaveKey<int> keyCounter = new SaveKey<int>("counter");

    public SerialSaveStore SaveStore { get; private set; }

    void Awake() {
      SaveStore = new SerialSaveStore(filename);
      SaveStore.StoreLoaded += SaveDataLoadedSuccessfully;
      SaveStore.StoreSaved += SaveDataSavedSuccessfully;
    }

    void Start() {
      SaveStore.Load();
    }

    private void SaveDataLoadedSuccessfully() {
      Debug.Log("Saved data loaded.");
      SaveStore.StoreLoaded -= SaveDataLoadedSuccessfully;
    }

    private void SaveDataSavedSuccessfully() {
      Debug.Log("Saved data saved.");
    }
  }
}
