namespace AndrewLord.UnitySerialSave {

  /// <summary>
  /// Rather than accessing all values through the save store, give read and write access to the value for a single 
  /// save key. You can also listen for value changes.
  /// </summary>
  public class SaveValueAccessor<T> {

    private SaveKey<T> saveKey;
    private SerialSaveStore saveStore;

    /// <summary>
    /// Create an accessor to the specified save store for the provided save key.
    /// </summary>
    /// <param name="saveKey">The key to read and write the value for.</param>
    /// <param name="saveStore">The save store to use.</param>
    public SaveValueAccessor(SaveKey<T> saveKey, SerialSaveStore saveStore) {
      this.saveKey = saveKey;
      this.saveStore = saveStore;
    }

    /// <summary>
    /// Event handler for the stored value been changed.
    /// </summary>
    /// <param name="saveValue">The new stored value.</param>
    public delegate void ValueChangedEventHandler(T saveValue);

    /// <summary>
    /// The stored value has been changed. If you set a value to the same value as it was before, then this will 
    /// still be notified.
    /// </summary>
    /// <param name="saveValue">The new stored value.</param>
    public event ValueChangedEventHandler ValueChanged = delegate(T saveValue) {};

    /// <summary>
    /// Get the stored value.
    /// </summary>
    /// <returns>The stored value.</returns>
    public T Get() {
      return saveStore.GetValue(saveKey);
    }
    
    /// <summary>
    /// Set a new stored value and notify any listeners.
    /// </summary>
    /// <param name="saveValue">The new value to store.</param>
    public void Set(T saveValue) {
      saveStore.SetValue(saveKey, saveValue);
      OnValueChanged(saveValue);
    }

    /// <summary>
    /// Set a new stored value, notify any listeners and then save the store.
    /// </summary>
    /// <param name="saveValue">The new value to store.</param>
    public void SetSave(T saveValue) {
      Set(saveValue);
      saveStore.Save();
    }

    /// <summary>
    /// Save the store.
    /// </summary>
    public void Save() {
      saveStore.Save();
    }
    
    private void OnValueChanged(T saveValue) {
      ValueChanged(saveValue);
    }
  }
}