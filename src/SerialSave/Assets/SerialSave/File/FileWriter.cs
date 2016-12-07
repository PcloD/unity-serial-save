namespace AndrewLord.UnitySerialSave {

  using System.IO;
  using System.Runtime.Serialization.Formatters.Binary;

  class FileWriter {

    public void SaveData(FilePathProvider filePathProvider, object saveData) {
      bool success = WriteData(filePathProvider, saveData);
      if (success) {
        CreateIfDoesNotExist(filePathProvider.FilePath);
        File.Replace(filePathProvider.TempFilePath, filePathProvider.FilePath, filePathProvider.BackupFilePath);
      }
    }

    bool WriteData(FilePathProvider filePathProvider, object saveData) {
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