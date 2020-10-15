using System.Collections;
using UnityEngine;

[System.Serializable]
public class PlayerData {
	
	public static PlayerData current;

	public string NamaPemain;
	public string[] durasiMain;
	public int unlockedLevel;
	public float[,] stats;

	public PlayerData(){
		stats = new float[3,4];
		durasiMain = new string[3];
		unlockedLevel = 1;
		/*
		unlockedLevel = mainScreen.releasedLevel;
		stats [0,0] = PlayerPrefs.GetFloat("bubble1",0);
		stats [0,1] = PlayerPrefs.GetFloat("soal1",0);
		stats [0,2] = PlayerPrefs.GetFloat("score1",0);
		durasiMain [0] = PlayerPrefs.GetString ("durasi2", "");
		stats [1,0] = PlayerPrefs.GetFloat("bubble2",0);
		stats [1,1] = PlayerPrefs.GetFloat("soal2",0);
		stats [1,2] = PlayerPrefs.GetFloat("score2",0);
		durasiMain [0] = PlayerPrefs.GetString ("durasi2", "");
		stats [2,0] = PlayerPrefs.GetFloat("bubble3",0);
		stats [2,1] = PlayerPrefs.GetFloat("soal3",0);
		stats [2,2] = PlayerPrefs.GetFloat("score3",0);
		durasiMain [2] = PlayerPrefs.GetString ("durasi3", "");
		NamaPemain = PlayerPrefs.GetString ("Nama", "");
		*/

	}
}
