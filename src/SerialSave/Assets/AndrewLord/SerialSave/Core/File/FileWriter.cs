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

  internal class FileWriter {

    internal void SaveData(FilePathProvider filePathProvider, object saveData) {
      bool success = WriteData(filePathProvider, saveData);
      if (success) {
        CreateIfDoesNotExist(filePathProvider.FilePath);
        File.Replace(filePathProvider.TempFilePath, filePathProvider.FilePath, filePathProvider.BackupFilePath);
      }
    }

    private bool WriteData(FilePathProvider filePathProvider, object saveData) {
      FileStream file = File.Create(filePathProvider.TempFilePath);
      try {
        BinaryFormatter writer = new BinaryFormatter();
        writer.Serialize(file, saveData);
        return true;
      } catch {
        return false;
      } finally {
        file.Close();
      }
    }

    private void CreateIfDoesNotExist(string filePath) {
      if (!DoesFileExist(filePath)) {
        File.Create(filePath);
      }
    }

    private bool DoesFileExist(string filePath) {
      FileInfo fileInfo = new FileInfo(filePath);
      return fileInfo != null && fileInfo.Exists;
    }
  }
}
