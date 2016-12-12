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

  using System.IO;
  using System.Runtime.Serialization.Formatters.Binary;

  internal class FileReader {

    internal object ReadData(FilePathProvider filePathProvider) {
      object loadedData = ReadFile(filePathProvider.FilePath);
      if (loadedData == null) {
        return ReadFile(filePathProvider.BackupFilePath);
      }
      return loadedData;
    }

    private object ReadFile(string filePath) {
      if (!DoesFileExist(filePath)) {
        return null;
      }
      FileStream file = File.Open(filePath, FileMode.Open);
      try {
        BinaryFormatter reader = new BinaryFormatter();
        return reader.Deserialize(file);
      } catch {
        return null;
      } finally {
        file.Close();
      }
    }

    private bool DoesFileExist(string filePath) {
      FileInfo fileInfo = new FileInfo(filePath);
      return fileInfo != null && fileInfo.Exists;
    }
  }
}
