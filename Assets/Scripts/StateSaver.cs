using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class StateSaver {

	public int maxLevel = 0;

	public void Save () {
		BinaryFormatter bf = new BinaryFormatter();
		Debug.Log (Application.persistentDataPath + "/levelSave.pole");
		PlayerData data = new PlayerData ();
		data.maxLevel = maxLevel;
		FileStream file = File.Create (Application.persistentDataPath + "/levelSave.pole");
		bf.Serialize (file, data);
		file.Close ();
	}

	public void Load() {
		if (File.Exists (Application.persistentDataPath + "/levelSave.pole")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open(Application.persistentDataPath + "/levelSave.pole", FileMode.Open);
			maxLevel = ((PlayerData)bf.Deserialize (file)).maxLevel;
			file.Close ();
		}
	}
}

[Serializable]
class PlayerData {
	public int maxLevel;
}