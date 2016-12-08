namespace AndrewLord.UnitySerialSave {

  /// <summary>
  /// Specify how the save data is read and written, for persistence.
  /// </summary>
  public interface Persister {

    /// <summary>
    /// Read the save data. This can be treated as an initial load into memory.
    /// </summary>
    /// <returns>The save data.</returns>
    object ReadData();

    /// <summary>
    /// Write the save data. This can be treated as running, whenever you want to save the data.
    /// </summary>
    /// <param name="saveData">The save data.</param>
    void SaveData(object saveData);

  }
}