namespace AndrewLord.UnitySerialSaveSample {

  using AndrewLord.UnitySerialSave;
  using UnityEngine;

  public class SaveDataStore : MonoBehaviour {

    private const string filename = "mydata";

    public static readonly SaveKey<int> keyCounter = new SaveKey<int>("counter");

    public SerialSaveStore SaveStore { get; private set; }

    void Awake() {
      SaveStore = new SerialSaveStore(filename);
      SaveStore.StoreLoaded += SaveDataLoadedSuccessfully;
      SaveStore.StoreSaved += SaveDataSavedSuccessfully;
    }

    void Start() {
      SaveStore.Load();
    }
    
    private void SaveDataLoadedSuccessfully() {
      Debug.Log("Saved data loaded.");
      SaveStore.StoreLoaded -= SaveDataLoadedSuccessfully;
    }

    private void SaveDataSavedSuccessfully() {
      Debug.Log("Saved data saved.");
    }
  }
}