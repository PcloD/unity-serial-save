namespace AndrewLord.UnitySerialSave {

  public class SaveKey<T> {

    public string Name { get; private set; }

    public SaveKey(string name) {
        Name = name;
    }
  }
}