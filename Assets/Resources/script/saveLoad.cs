using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class saveLoad{

	public static List<PlayerData> GameTersimpan = new List<PlayerData>();

	//it's static so we can call it from anywhere
	public static void Save() {
		saveLoad.GameTersimpan.Add(PlayerData.current);
		BinaryFormatter bf = new BinaryFormatter();
		if(!Directory.Exists(Application.dataPath+"/saves")){
			Directory.CreateDirectory (Application.dataPath + "/saves");
		}
		FileStream file = File.Create (Application.dataPath + "/saves/ChemmyGameSaved.cws");
		bf.Serialize(file, saveLoad.GameTersimpan);
		file.Close();
	}	
		
	public static void Load() {
		if(File.Exists(Application.dataPath + "/saves/ChemmyGameSaved.cws")) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.dataPath + "/saves/ChemmyGameSaved.cws", FileMode.Open);
			saveLoad.GameTersimpan = (List<PlayerData>)bf.Deserialize(file);
			file.Close();
		}
	}

}

