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
namespace AndrewLord.UnitySerialSave.UnitTests {

  using NUnit.Framework;
  using UnityEngine;

  public class FilePathProviderTest {

    private const string Filename = "somefile";

    private FilePathProvider provider;

    [SetUp]
    public void SetUp() {
      provider = new FilePathProvider(Filename);
    }

    [Test]
    public void WhenFilePath_ThenFilePathReturned() {
      string expected = Application.persistentDataPath + "/" + Filename + ".dat";

      string actual = provider.FilePath;

      Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void WhenTempFilePath_ThenTempFilePathReturned() {
      string expected = Application.persistentDataPath + "/" + Filename + ".dat.temp";

      string actual = provider.TempFilePath;

      Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void WhenBackupFilePath_ThenBackupFilePathReturned() {
      string expected = Application.persistentDataPath + "/" + Filename + ".dat.backup";

      string actual = provider.BackupFilePath;

      Assert.That(actual, Is.EqualTo(expected));
    }
  }
}
