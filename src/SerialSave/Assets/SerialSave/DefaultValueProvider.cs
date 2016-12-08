namespace AndrewLord.UnitySerialSave {

  public interface DefaultValueProvider {

    object GetDefaultValue(string saveKey);
    
  }
}