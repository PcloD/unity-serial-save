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