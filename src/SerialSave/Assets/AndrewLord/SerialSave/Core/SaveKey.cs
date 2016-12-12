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
  /// A typed key, which can be used to provide the value from the store in the correct type without you needing to
  /// specify it when retrieving.
  /// </summary>
  public class SaveKey<T> {

    /// <summary>
    /// The key name.
    /// </summary>
    /// <returns>The key name.</returns>
    public string Name { get; private set; }

    /// <summary>
    /// Create a save key from its name, specifying the type.
    /// </summary>
    /// <param name="name">The key name.</param>
    public SaveKey(string name) {
        Name = name;
    }
  }
}
