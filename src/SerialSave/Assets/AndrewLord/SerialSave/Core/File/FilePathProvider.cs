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

  using UnityEngine;

  public class FilePathProvider {

    private const string FileExtension = ".dat";
    private const string TempFileSuffix = ".temp";
    private const string BackupFileSuffix = ".backup";

    private string filename;

    public FilePathProvider(string filename) {
      this.filename = filename;
      FilePath = CreateFilePath();
      TempFilePath = CreateFilePath() + TempFileSuffix;
      BackupFilePath = CreateFilePath() + BackupFileSuffix;
    }

    private string CreateFilePath() {
      return Application.persistentDataPath + "/" + filename + FileExtension;
    }

    public string FilePath { get; private set; }

    public string TempFilePath { get; private set; }

    public string BackupFilePath { get; private set; }

  }
}
