namespace AndrewLord.UnitySerialSave {

  /// <summary>
  /// Write access to a SerialSaveStore.
  /// </summary>
  public interface SerialSaveStoreWriter {

    /// <summary>
    /// Store a value into the store for the provided save key. Afterwards a value changed event will be thrown.
    /// </summary>
    /// <param name="saveKey">The key to store the value for.</param>
    /// <param name="saveValue">The value to store.</param>
    void SetValue<T>(SaveKey<T> saveKey, T saveValue);

    /// <summary>
    /// Store a value into the store for the provided save key. Afterwards a value changed event will be thrown.
    /// </summary>
    /// <param name="saveKey">The key to store the value for.</param>
    /// <param name="saveValue">The value to store.</param>
    void SetValue(string saveKey, object saveValue);

    /// <summary>
    /// Save the data to the persister. Afterwards a saved event is fired.
    /// </summary>
    void Save();
  }
}