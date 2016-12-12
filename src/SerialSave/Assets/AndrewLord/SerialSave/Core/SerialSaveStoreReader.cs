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
  /// Read access to a SerialSaveStore.
  /// </summary>
  public interface SerialSaveStoreReader {

    /// <summary>
    /// Retrieve a value from the store, using a typed key. The value will be returned in the correct type, using
    /// the save key. If the value is not present then the default value for the type will be returned. However, if
    /// there is a value stored for that key of a different type, then an exception will be thrown.
    /// </summary>
    /// <param name="saveKey">The typed key to retrieve the value for.</param>
    /// <returns>The stored value.</returns>
    T GetValue<T>(SaveKey<T> saveKey);

    /// <summary>
    /// Retrieve a value from the store, which will be cast to the specified type. If the value is not present then the
    /// default value for the type will be returned. However, if there is a value stored for that key of a different
    /// type, then an exception will be thrown.
    /// </summary>
    /// <param name="saveKey">The key to retrieve the value for.</param>
    /// <returns>The stored value.</returns>
    T GetValue<T>(string saveKey);

    /// <summary>
    /// Retrieve a value from the store. If the value is not present and there is a default value provider, then the
    /// default value from there will be returned, else if there is no provider then null will be returned.
    /// </summary>
    /// <param name="saveKey">The key to retrieve the value for.</param>
    /// <returns>The stored value.</returns>
    object GetValue(string saveKey);

    /// <summary>
    /// Whether there is a value stored for the key.
    /// </summary>
    /// <param name="saveKey">The key.</param>
    /// <returns>Whether there is a value stored.</returns>
    bool HasValue<T>(SaveKey<T> saveKey);

    /// <summary>
    /// Whether there is a value stored for the key.
    /// </summary>
    /// <param name="saveKey">The key.</param>
    /// <returns>Whether there is a value stored.</returns>
    bool HasValue(string name);

  }
}
