# SerialSave

[![Version](https://img.shields.io/badge/Version-v0.1.0-blue.svg)](https://github.com/andrewlord1990/unity-serial-save/releases/latest)
[![Build Status](https://travis-ci.org/andrewlord1990/unity-serial-save.svg?branch=master)](https://travis-ci.org/andrewlord1990/unity-serial-save)
[![License](https://img.shields.io/badge/license-Apache%202.0-green.svg) ](https://github.com/andrewlord1990/unity-serial-save/blob/master/LICENSE)

A simple save file solution for your Unity games which will work on all platforms that support local file storage. It uses binary serialization for simplicity and also to hide the saved values from your users without needing encryption. Any class which is serializable is supported, however, to avoid problems with versioning you may wish to stick to the primitive types.

## Download

You can obtain SerialSave by [using this link](https://github.com/andrewlord1990/unity-serial-save/releases/download/v0.1.0/SerialSave.0.1.0.unitypackage).

Once you have the `unitypackage` file, you can import it into your Unity project. If your project is already open then you can simply double-click the downloaded package. Alternatively, go to `Assets -> Import Package -> Custom Package` within the Unity editor.

## Main Features

- Quickly and easily add save game support to your game.
- Store values of different types in the same store.
- Use a typed key class so that the value is automatically returned as the correct type.
- Alternatively, just access values with a string key and specify the type in the call.
- Provide default values to use for each key, if a value is not already stored.
- Set of interfaces so you could give part of your game access only to a subset of the full set of operations. Such as read access, write access and saving/loading access.

## Usage

Create and load up the save store.

```cs
private const string Filename = "some_filename";

private SerialSaveStore saveStore;

void Awake() {
  saveStore = new SerialSaveStore(Filename, new SaveStoreDefaults());
  saveStore.StoreLoaded += SaveStoreLoadedSuccessfully;
  saveStore.Load();
}

private void SaveStoreLoadedSuccessfully() {
   // Do something
}
```

Save the store.

```cs
saveStore.Save();
```

Read and write values using typed key.

```cs
public static readonly SaveKey<int> ScoreKey = new SaveKey<int>("score");

public void DisplayScore() {
   int score = saveStore.GetValue(ScoreKey);
   scoreLabel.text = score.ToString();
}

public void UpdateScore(int newScore) {
  saveStore.SetValue(ScoreKey, newScore);
}
```

Read values using raw key.

```cs
public static readonly string ScoreKey = "score";

public void DisplayScore() {
   int score = saveStore.GetValue<int>(ScoreKey);
   scoreLabel.text = score.ToString();
}

public void UpdateScore(int newScore) {
  saveStore.SetValue(ScoreKey, newScore);
}
```
Using typed keys is the suggested approach, due to it meaning the value's type is kept together with the key. This means all users of the save store don't need to remember and specify the type when retrieving the value.


## Suggestions

If there are any features that have been missed that you are interested in then please open an issue. Thanks!

## License

    Copyright 2016 Andrew Lord

    Licensed under the Apache License, Version 2.0 (the "License");
    you may not use this file except in compliance with the License.
    You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

    Unless required by applicable law or agreed to in writing, software
    distributed under the License is distributed on an "AS IS" BASIS,
    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
    See the License for the specific language governing permissions and
    limitations under the License.
