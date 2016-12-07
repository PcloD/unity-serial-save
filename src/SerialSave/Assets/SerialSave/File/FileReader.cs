namespace AndrewLord.UnitySerialSave {

  using System.IO;
  using System.Runtime.Serialization.Formatters.Binary;

  class FileReader {

    public object ReadData(FilePathProvider filePathProvider) {
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