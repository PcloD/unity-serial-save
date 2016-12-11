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