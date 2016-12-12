namespace AndrewLord.UnitySerialSave {

  public interface SerialSaveStoreLoader {

    /// <summary>
    /// Load saved data from the persister, if none is found use an empty dictionary. Afterwards a loaded event is 
    /// fired.
    /// </summary>
    void Load();

  }
}