namespace AndrewLord.UnitySerialSaveSample {

  using AndrewLord.UnitySerialSave;
  using UnityEngine;
  using UnityEngine.UI;

  public class CounterLabel : MonoBehaviour {

    public SaveDataStore saveDataStore;
    public Text label;

    private SerialSaveStore saveStore;

    void Start() {
      saveStore = saveDataStore.SaveStore;
      saveStore.ValueChanged += CounterValueChanged;
      saveStore.StoreLoaded += StoreLoaded;
    }

    private void StoreLoaded() {
      CounterValueChanged(SaveDataStore.keyCounter.Name);
      saveStore.StoreLoaded -= StoreLoaded;
    }

    private void CounterValueChanged(string keyName) {
      if (keyName.Equals(SaveDataStore.keyCounter.Name)) {
        int counter = saveStore.GetValue<int>(keyName);
        label.text = counter.ToString();
      }
    }
  }
}