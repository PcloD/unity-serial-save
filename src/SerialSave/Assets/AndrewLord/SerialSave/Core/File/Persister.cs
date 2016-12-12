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
  /// Specify how the save data is read and written, for persistence.
  /// </summary>
  public interface Persister {

    /// <summary>
    /// Read the save data. This can be treated as an initial load into memory.
    /// </summary>
    /// <returns>The save data.</returns>
    object ReadData();

    /// <summary>
    /// Write the save data. This can be treated as running, whenever you want to save the data.
    /// </summary>
    /// <param name="saveData">The save data.</param>
    void SaveData(object saveData);

  }
}
