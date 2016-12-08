namespace AndrewLord.UnitySerialSave {
    
  using UnityEngine;

  internal class FilePathProvider {

    private const string FileExtension = ".dat";
    private const string TempFileSuffix = ".temp";
    private const string BackupFileSuffix = ".backup";

    private string filename;

    internal FilePathProvider(string filename) {
      this.filename = filename;
      FilePath = CreateFilePath();
      TempFilePath = CreateFilePath() + TempFileSuffix;
      BackupFilePath = CreateFilePath() + BackupFileSuffix;
    }

    private string CreateFilePath() {
      return Application.persistentDataPath + "/" + filename + FileExtension;
    }

    internal string FilePath { get; private set; }

    internal string TempFilePath { get; private set; }

    internal string BackupFilePath { get; private set; }
    
  }
}