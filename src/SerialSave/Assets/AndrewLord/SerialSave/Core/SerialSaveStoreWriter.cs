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
namespace AndrewLord.UnitySerialSave {

  /// <summary>
  /// Write access to a SerialSaveStore.
  /// </summary>
  public interface SerialSaveStoreWriter {

    /// <summary>
    /// Store a value into the store for the provided save key. Afterwards a value changed event will be thrown.
    /// </summary>
    /// <param name="saveKey">The key to store the value for.</param>
    /// <param name="saveValue">The value to store.</param>
    void SetValue<T>(SaveKey<T> saveKey, T saveValue);

    /// <summary>
    /// Store a value into the store for the provided save key. Afterwards a value changed event will be thrown.
    /// </summary>
    /// <param name="saveKey">The key to store the value for.</param>
    /// <param name="saveValue">The value to store.</param>
    void SetValue(string saveKey, object saveValue);

    /// <summary>
    /// Save the data to the persister. Afterwards a saved event is fired.
    /// </summary>
    void Save();
  }
}
