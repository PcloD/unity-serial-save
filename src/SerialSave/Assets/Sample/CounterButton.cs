namespace AndrewLord.UnitySerialSaveSample {

	using AndrewLord.UnitySerialSave;
	using UnityEngine;

	public class CounterButton : MonoBehaviour {

		public SaveDataStore saveDataStore;

		private SerialSaveStore saveStore;

		void Start() {
			saveStore = saveDataStore.SaveStore;
		}

		public void IncrementCounter() {
			int currentCount = saveStore.GetValue(SaveDataStore.keyCounter);
			saveStore.SetValue(SaveDataStore.keyCounter, currentCount + 1);
			saveStore.Save();
		}
	}
}