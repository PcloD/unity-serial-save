namespace AndrewLord.UnitySerialSave {

  /// <summary>
  /// A typed key, which can be used to provide the value from the store in the correct type without you needing to 
  /// specify it when retrieving.
  /// </summary>
  public class SaveKey<T> {

    /// <summary>
    /// The key name.
    /// </summary>
    /// <returns>The key name.</returns>
    public string Name { get; private set; }

    /// <summary>
    /// Create a save key from its name, specifying the type.
    /// </summary>
    /// <param name="name">The key name.</param>
    public SaveKey(string name) {
        Name = name;
    }
  }
}