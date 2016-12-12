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

  internal class FilePersister : Persister {

    private FilePathProvider filePathProvider;
    private FileReader reader;
    private FileWriter writer;

    internal FilePersister(string filename) {
      filePathProvider = new FilePathProvider(filename);
      reader = new FileReader();
      writer = new FileWriter();
    }

    public object ReadData() {
        return reader.ReadData(filePathProvider);
    }

    public void SaveData(object saveData) {
        writer.SaveData(filePathProvider, saveData);
    }
  }
}
