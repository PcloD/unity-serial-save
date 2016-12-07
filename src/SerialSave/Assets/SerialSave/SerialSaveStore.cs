namespace AndrewLord.UnitySerialSave {

    using System.Collections.Generic;

    /// <summary>
    /// Store save game data values. These values are stored in memory and can be persisted to disk.
    /// Binary serialization is used for persistence, so the data won't be readable by users.
    /// Persistence is performed through an interface, so you could customise the saving and loading if you wished.
    /// </summary>
    public class SerialSaveStore {

    /// <summary>
    /// Event handler for saved data being loaded.
    /// </summary>
    public delegate void StoreLoadedEventHandler();

    /// <summary>
    /// Saved data has been successfully loaded.
    /// </summary>
    public event StoreLoadedEventHandler StoreLoaded = delegate {};

    /// <summary>
    /// Event handler for saved data being saved.
    /// </summary>
    public delegate void StoreSavedEventHandler();

    /// <summary>
    /// Saved data has been successfully saved.
    /// </summary>
    public event StoreSavedEventHandler StoreSaved = delegate {};

    /// <summary>
    /// Event handler for saved data value changes.
    /// </summary>
    /// /// <param name="saveKey">The key of the saved value.</param>
    public delegate void ValueChangedEventHandler(string saveKey);

    /// <summary>
    /// A saved value has changed.
    /// </summary>
    public event ValueChangedEventHandler ValueChanged = delegate(string saveKey) {};

    private Persister persister;
    private Dictionary<string, object> savedData;

    /// <summary>
    /// Whether saved data has been loaded.
    /// </summary>
    /// <returns>Whether saved data has been loaded.</returns>
    public bool Loaded { get; private set; }

    /// <summary>
    /// Create a save store, which will persist data to disk. Data will be serialized to a file with the provided filename.
    /// </summary>
    /// <param name="filename">The name of the file to save data to.</param>
    public SerialSaveStore(string filename) : this(new FilePersister(filename)) {
    }

    /// <summary>
    /// Create a save store, which will save and load data through the provided persister. This allows you to customise the saving and loading mechanism used.
    /// </summary>
    /// <param name="persister"></param>
    public SerialSaveStore(Persister persister) {
      this.persister = persister;
    }

    /// <summary>
    /// Load saved data from the persister, if none is found use an empty dictionary. Afterwards a loaded event is fired.
    /// </summary>
    public void Load() {
      savedData = (Dictionary<string, object>) persister.ReadData();
      if (savedData == null) {
        savedData = new Dictionary<string, object>();
      }
      OnStoreLoaded();
    }

    /// <summary>
    /// Save the data to the persister. Afterwards a saved event is fired.
    /// </summary>
    public void Save() {
      persister.SaveData(savedData);
      OnStoreSaved();
    }

    public T GetValue<T>(SaveKey<T> saveKey) {
      return GetValue<T>(saveKey.Name);
    }

    public T GetValue<T>(string name) {
      object saveValue;
      savedData.TryGetValue(name, out saveValue);
      return (T) saveValue;
    }

    public void SetValue<T>(SaveKey<T> saveKey, T saveValue) {
      SetValue(saveKey.Name, saveValue);
    }

    public void SetValue(string saveKey, object saveValue) {
      savedData[saveKey] = saveValue;
      OnValueChanged(saveKey);
    }

    public bool HasValue<T>(SaveKey<T> saveKey) {
      return HasValue(saveKey.Name);
    }

    public bool HasValue(string name) {
      return savedData.ContainsKey(name);
    }

    private void OnStoreLoaded() {
      Loaded = true;
      StoreLoaded();
    }

    private void OnStoreSaved() {
      StoreSaved();
    }

    private void OnValueChanged(string saveKey) {
      ValueChanged(saveKey);
    }
  }
}