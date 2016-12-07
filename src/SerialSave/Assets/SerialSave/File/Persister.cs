namespace AndrewLord.UnitySerialSave {

  public interface Persister {

    object ReadData();

    void SaveData(object saveData);

  }
}